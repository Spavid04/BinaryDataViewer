using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace DataViewer
{
    public partial class MainForm : Form
    {
        private OptionValues Options = new OptionValues();

        private Bitmap TheImage = null;

        private string FilePath = null;
        private Stream DataStream = null;
        private long DataStreamLength = 0;

        public MainForm()
        {
            this.Disposed += (_, _) => this.DisposeStuff();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.PplNorefresh = true;
            this.pplNumericUpDown.Value = this.mainPictureBox.Width;
            this.PplNorefresh = false;
            this.pfComboBox.SelectedIndex = 0;
        }

        #region Refresh methods
        
        private void HardRefresh()
        {
            this.mainPictureBox.Image = null;
            this.mainPictureBox.Invalidate();
            this.TheImage?.Dispose();

            this.TheImage = new Bitmap(this.Options.MaxImageWidth, this.Options.MaxImageHeight,
                BitmapOperations.DataPixelFormatToPixelFormat(this.Options.DPFormat));
            if (this.TheImage.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                // Graphics cannot use indexed formats
                // also, probably needed only when the alpha channel is used
                using (Graphics g = Graphics.FromImage(this.TheImage))
                {
                    g.Clear(Color.Black);
                }
            }
            else
            {
                // set up the color palette
                ColorPalette palette = this.TheImage.Palette;
                for (int i = 0; i < 256; i++)
                {
                    palette.Entries[i] = Color.FromArgb(i, i, i);
                }
                this.TheImage.Palette = palette;
            }

            this.mainPictureBox.Image = this.TheImage;

            BitmapOperations.EnsureBuffer((long)this.Options.MaxImageWidth * this.Options.MaxImageHeight *
                                          this.BytesPerPixel);
            this.SoftRefresh();
        }

        private void SoftRefresh()
        {
            if (this.DataStream == null)
            {
                return;
            }

            BitmapOperations.CopyDataAsPixels(this.DataStream, this.Options.Offset, this.TheImage, this.Options.PixelsPerLine, this.Options.DPFormat);
            this.mainPictureBox.Invalidate();
        }

        #endregion

        #region Control events - Quick options

        private bool PplNosync = false;
        private void pplTrackBar_Scroll(object sender, EventArgs e)
        {
            this.PplNosync = true;
            this.pplNumericUpDown.Value = this.pplTrackBar.Value;
            this.PplNosync = false;
        }

        private bool PplNorefresh = false;
        private void pplNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!this.PplNosync)
            {
                this.pplTrackBar.Value = (int)this.pplNumericUpDown.Value;
            }
            this.Options.PixelsPerLine = (int)this.pplNumericUpDown.Value;

            this.UpdateRoundings();

            if (this.autoRedrawCheckBox.Checked && !this.PplNorefresh)
            {
                this.SoftRefresh();
            }
        }

        #region Offset rounding stuff
        
        private void UpdateRoundings()
        {
            long rounding = 1;

            //todo trackbar short and long change

            if (this.noSnapRadioButton.Checked)
            {
                rounding = 1;
            }
            else if (this.pixelSnapRadioButton.Checked)
            {
                rounding = this.BytesPerPixel;
            }
            else if (this.lineSnapRadioButton.Checked)
            {
                rounding = this.BytesPerPixel * this.Options.PixelsPerLine;
            }

            this.oNumericUpDown.Increment = rounding;
        }

        private static long TrackbarToOffset(int trackbarValue, int trackbarMaximum, long maxOffset, long rounding, out int trackbarRoundedValue)
        {
            double fraction = (double)trackbarValue / trackbarMaximum;
            long desiredOffset = (long)(maxOffset * fraction);

            if (rounding != 1)
            {
                // rounding needed
                desiredOffset = (long)Math.Round((double)desiredOffset / rounding, MidpointRounding.AwayFromZero) *
                                rounding;

                fraction = (double)desiredOffset / maxOffset;
                trackbarRoundedValue = (int)(fraction * trackbarMaximum);
            }
            else
            {
                trackbarRoundedValue = trackbarValue;
            }

            return desiredOffset;
        }

        #endregion

        private bool ONosync = false;
        private bool ONoscroll = false;
        private void oTrackBar_Scroll(object sender, EventArgs e)
        {
            if (this.ONoscroll)
            {
                return;
            }

            this.ONosync = true;

            this.UpdateRoundings();
            int roundedTrackbar;
            this.oNumericUpDown.Value = Math.Min(this.oNumericUpDown.Maximum,
                TrackbarToOffset(this.oTrackBar.Value, this.oTrackBar.Maximum, this.DataStreamLength,
                    (long)this.oNumericUpDown.Increment, out roundedTrackbar)
            );

            this.ONoscroll = true;
            this.oTrackBar.Value = roundedTrackbar;
            this.ONoscroll = false;

            this.ONosync = false;
        }

        private void oNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!this.ONosync)
            {
                this.oTrackBar.Value = (int)(((double)this.oNumericUpDown.Value / this.DataStreamLength) * this.oTrackBar.Maximum);
            }
            this.Options.Offset = (long)this.oNumericUpDown.Value;

            if (this.autoRedrawCheckBox.Checked)
            {
                this.SoftRefresh();
            }
        }

        private void SnapChangedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateRoundings();
        }

        private void hexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.oNumericUpDown.Hexadecimal = this.hexCheckBox.Checked;
        }

        private void pfComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Options.DPFormat = BitmapOperations.StringToDataPixelFormat(this.pfComboBox.Text);
            this.UpdateRoundings();
            this.HardRefresh();
        }

        #endregion

        private void OpenFile(string path)
        {
            this.DataStream?.Dispose();
            this.DataStream = null;

            this.oNumericUpDown.Value = 0;

            this.FilePath = path;
            this.DataStream = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            this.DataStreamLength = this.DataStream.Length;

            this.oNumericUpDown.Maximum = this.DataStream.Length;
            this.Text = $"Data Viewer - {this.FilePath}";

            this.SoftRefresh();
        }

        #region Control events - Others

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.OpenFile(this.mainOpenFileDialog.FileName);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var optionsForm = new OptionsForm(this.Options);
            optionsForm.ShowDialog();

            this.pplNumericUpDown.Maximum = this.pplTrackBar.Maximum = this.Options.MaxImageWidth;

            this.HardRefresh();
        }

        private void redrawButton_Click(object sender, EventArgs e)
        {
            this.SoftRefresh();
        }

        private void autoRedrawCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoRedrawCheckBox.Checked)
            {
                this.SoftRefresh();
            }
        }

        private void SaveImage(Bitmap image)
        {
            if (this.saveOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(this.saveOpenFileDialog.FileName);
                MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveImportantButton_Click(object sender, EventArgs e)
        {
            this.SoftRefresh();

            int width = this.Options.PixelsPerLine;
            int dataPixels = (int)Math.Round((double)this.DataStreamLength / this.BytesPerPixel,
                MidpointRounding.ToPositiveInfinity);
            int height = Math.Min(this.mainPictureBox.Height,
                (int)Math.Round((double)dataPixels / width, MidpointRounding.ToPositiveInfinity));
            PixelFormat pf =
                BitmapOperations.DataPixelFormatToPixelFormat(this.Options.DPFormat) == PixelFormat.Format32bppArgb
                    ? PixelFormat.Format32bppArgb
                    : PixelFormat.Format24bppRgb;

            using (var b = new Bitmap(width, height, pf))
            {
                using (var g = Graphics.FromImage(b))
                {
                    g.DrawImage(this.TheImage,
                        new Rectangle(0, 0, width, height),
                        new Rectangle(0, 0, width, height),
                        GraphicsUnit.Pixel); 
                }

                this.SaveImage(b);
            }
        }

        private void saveAllButton_Click(object sender, EventArgs e)
        {
            this.SoftRefresh();
            this.SaveImage(this.TheImage);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0)
            {
                return;
            }

            this.OpenFile(files[0]);
        }

        #endregion

        private int BytesPerPixel =>
            BitmapOperations.GetBytesPerPixel(BitmapOperations.DataPixelFormatToPixelFormat(this.Options.DPFormat));

        private void DisposeStuff()
        {
            this.TheImage?.Dispose();
            this.DataStream?.Dispose();
        }
    }

    public class OptionValues
    {
        public int MaxImageWidth = 2048;
        public int MaxImageHeight = 1000;

        public int PixelsPerLine = 1000;
        public long Offset = 0;
        public BitmapOperations.DataPixelFormat DPFormat = BitmapOperations.StringToDataPixelFormat("RGB");
    }
}
