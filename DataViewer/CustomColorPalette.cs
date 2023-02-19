using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace DataViewer
{
    public class CustomColorPalette
    {
#region Color+palette statics

        private static readonly Color[] _grayscaleColors;
        private static readonly Color[] _blackColors;

        static CustomColorPalette()
        {
            _grayscaleColors = new Color[256];
            for (int i = 0; i < _grayscaleColors.Length; i++)
            {
                _grayscaleColors[i] = Color.FromArgb(i, i, i);
            }

            _blackColors = new Color[256];
            for (int i = 0; i < _blackColors.Length; i++)
            {
                _blackColors[i] = Color.Black;
            }
        }

        private static Color[] GrayscalePaletteCopy
        {
            get
            {
                var palette = new Color[256];
                Array.Copy(_grayscaleColors, palette, palette.Length);
                return palette;
            }
        }

        private static Color[] BlackPaletteCopy
        {
            get
            {
                var palette = new Color[256];
                Array.Copy(_blackColors, palette, palette.Length);
                return palette;
            }
        }

        public static CustomColorPalette Grayscale => new CustomColorPalette(GrayscalePaletteCopy);

        public static CustomColorPalette Black => new CustomColorPalette(BlackPaletteCopy);

        #endregion

#region String description statics

        private static readonly Regex DescriptionLineRegex = new Regex(@"
^
(?:
  (?<all_bytes> \*)
  | (?<from_byte> (?:(?:0x)?[0-9a-f]{1,3}h? | '..??') )
    (?:\s* - \s*(?<to_byte> (?:(?:0x)?[0-9a-f]{1,3}h? | '..??') ))?
)
\s* -> \s*
(?:
  (?<color_byteval> \*)
  | (?:\#? (?<color_hex> [0-9a-f]{6}))
  | (?<color_named> \w+)
)
$
", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        private static void ApplyDescriptionToColorArray(string description, Color[] colors)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return;
            }
            if (colors == null || colors.Length != 256)
            {
                throw new ArgumentException("Invalid color array. Must be of size 256!");
            }

            string[] lines = description.Split(new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (string line in lines)
            {
                ApplyDescriptionLineToColorArray(line, colors);
            }
        }

        private static void ApplyDescriptionLineToColorArray(string line, Color[] colors)
        {
            if (line.TrimStart().StartsWith("#"))
            {
                // a comment; ignore
                return;
            }

            Match match = DescriptionLineRegex.Match(line);
            if (!match.Success)
            {
                throw new FormatException($"Invalid description line: {line}");
            }

            byte startIndex;
            byte endIndex;
            if (match.Groups["from_byte"].Success)
            {
                startIndex = endIndex = Utils.ByteFromLiteral(match.Groups["from_byte"].Value);
                if (match.Groups["to_byte"].Success)
                {
                    endIndex = Utils.ByteFromLiteral(match.Groups["to_byte"].Value);
                }

                if (startIndex > endIndex)
                {
                    byte t = startIndex;
                    startIndex = endIndex;
                    endIndex = t;
                }
            }
            else
            {
                startIndex = 0;
                endIndex = 255;
            }

            Func<byte, Color> colorFunction = null;
            if (match.Groups["color_byteval"].Success)
            {
                colorFunction = b => _grayscaleColors[b];
            }
            else if (match.Groups["color_hex"].Success)
            {
                string hex = match.Groups["color_hex"].Value;
                int r = Convert.ToInt32(hex[0..2], 16);
                int g = Convert.ToInt32(hex[2..4], 16);
                int b = Convert.ToInt32(hex[4..6], 16);

                Color color = Color.FromArgb(r, g, b);
                colorFunction = _ => color;
            }
            else if (match.Groups["color_named"].Success)
            {
                string colorName = match.Groups["color_named"].Value;
                Color color = Color.FromName(colorName);
                if (color.ToArgb() == 0)
                {
                    throw new ArgumentException($"Unknown color name \"{colorName}\"");
                }
                colorFunction = _ => color;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                colors[i] = colorFunction((byte)i);
            }
        }

#endregion

        public Color[] Palette { get; private set; }

        /// <summary>
        /// Creates the default "grayscale" color palette.
        /// </summary>
        public CustomColorPalette() : this(GrayscalePaletteCopy)
        {

        }

        /// <summary>
        /// Creates a palette from the given description string.
        /// </summary>
        public CustomColorPalette(string paletteDescription)
        {
            var allBlack = BlackPaletteCopy;
            ApplyDescriptionToColorArray(paletteDescription, allBlack);
            this.Palette = allBlack;
        }
        
        /// <param name="colors">256 elements maximum</param>
        public CustomColorPalette(Color[] colors)
        {
            this.Palette = new Color[256];
            Array.Copy(colors, this.Palette, this.Palette.Length);
        }

        public void SetColorsToPalette(ColorPalette palette)
        {
            for (int i = 0; i < 256; i++)
            {
                palette.Entries[i] = this.Palette[i];
            }
        }

        // todo ToString description
    }
}
