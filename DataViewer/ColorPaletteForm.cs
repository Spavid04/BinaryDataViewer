using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataViewer
{
    public partial class ColorPaletteForm : Form
    {
        public CustomColorPalette Palette;
        private readonly Timer TextChangedDelayer;
        private readonly Color LabelOkForegroundColor;

        public ColorPaletteForm()
        {
            InitializeComponent();

            this.LabelOkForegroundColor = this.statusLabel.ForeColor;

            this.Palette = new CustomColorPalette(this.colorPaletteRichTextBox.Text);
            this.TextChangedDelayer = new Timer();
            this.TextChangedDelayer.Tick += TextChangedDelayerOnTick;
            this.TextChangedDelayer.Interval = 500;

            this.colorPaletteRichTextBox.TextChanged += ColorPaletteRichTextBoxOnTextChanged;

            this.RefreshPreview();
        }

        public delegate void PaletteParsedEvent(CustomColorPalette palette);
        public event PaletteParsedEvent PaletteParsed;

        private void ColorPaletteForm_Resize(object sender, EventArgs e)
        {
            this.RefreshPreview();
        }

        private void ColorPaletteRichTextBoxOnTextChanged(object sender, EventArgs e)
        {
            if (this.TextChangedDelayer.Enabled)
            {
                this.TextChangedDelayer.Stop();
            }
            this.TextChangedDelayer.Start();
        }

        private void TextChangedDelayerOnTick(object sender, EventArgs e)
        {
            CustomColorPalette newPalette = null;

            try
            {
                newPalette = new CustomColorPalette(this.colorPaletteRichTextBox.Text);
            }
            catch (Exception exception)
            {
                this.statusLabel.Text = "Parsing error: " + exception.Message;
                this.statusLabel.ForeColor = Color.DarkRed;
            }

            if (newPalette != null)
            {
                this.statusLabel.Text = "OK";
                this.statusLabel.ForeColor = this.LabelOkForegroundColor;
                this.Palette = newPalette;
                this.RefreshPreview();

                this.PaletteParsed?.Invoke(newPalette);
            }

            this.TextChangedDelayer.Stop();
        }

        private void RefreshPreview()
        {
            if (this.palettePictureBox.Image == null ||
                this.palettePictureBox.Width != this.palettePictureBox.Image.Width ||
                this.palettePictureBox.Height != this.palettePictureBox.Image.Height)
            {
                this.palettePictureBox.Image = GetPreviewImage(this.palettePictureBox.Width);
            }

            var palette = this.palettePictureBox.Image.Palette;
            this.Palette.SetColorsToPalette(palette);
            this.palettePictureBox.Image.Palette = palette;

            this.palettePictureBox.Invalidate();
        }

        private static Bitmap GetPreviewImage(int width)
        {
            var bitmap = new Bitmap(width, 256, PixelFormat.Format8bppIndexed);
            var data = bitmap.LockBits(new Rectangle(0, 0, width, 256), ImageLockMode.WriteOnly,
                PixelFormat.Format8bppIndexed);

            for (int i = 0; i < 256; i++)
            {
                Utils.Memset(data.Scan0 + i * data.Stride, i, width);
            }

            bitmap.UnlockBits(data);
            return bitmap;
        }
    }
}
