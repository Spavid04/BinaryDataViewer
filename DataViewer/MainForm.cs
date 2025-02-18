﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace DataViewer
{
    public partial class MainForm : Form
    {
        private readonly string[] ProgramArgs;
        private OptionValues Options = new OptionValues();
        private ColorPaletteForm PaletteForm = null;

        private Bitmap TheImage = null;

        private string FilePath = null;
        private Stream DataStream = null;
        private long DataStreamLength = 0;

        public MainForm(string[] args = null)
        {
            this.ProgramArgs = args;
            this.Disposed += (_, _) => this.DisposeStuff();
            InitializeComponent();
            this.mainPictureBox.MouseWheel += MainPictureBoxOnMouseWheel;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.PplNorefresh = true;
            this.pplNumericUpDown.Value = this.mainPictureBox.Width;
            this.PplNorefresh = false;
            this.pfComboBox.SelectedIndex = 0;

            if (this.ProgramArgs != null && this.ProgramArgs.Length >= 1)
            {
                string path = this.ProgramArgs[0];
                if (File.Exists(path))
                {
                    this.OpenFile(path);
                }
            }
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

            this.SoftRefresh();
        }

        private void SoftRefresh()
        {
            if (this.DataStream == null)
            {
                return;
            }

            try
            {
                BitmapOperations.CopyDataAsPixels(this.DataStream, this.Options.Offset, this.TheImage, this.Options.PixelsPerLine, this.Options.PixelScaling, this.Options.DPFormat);
            }
            catch (IOException e)
            {
                MessageBox.Show($"Failed to read file. Error:\n\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CleanupStream();
                return;
            }

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
        private void oTrackBar_Scroll(object sender, EventArgs e)
        {
            this.ONosync = true;

            this.UpdateRoundings();
            int roundedTrackbar;
            this.oNumericUpDown.Value = Math.Min(this.oNumericUpDown.Maximum,
                TrackbarToOffset(this.oTrackBar.Value, this.oTrackBar.Maximum, this.DataStreamLength,
                    (long)this.oNumericUpDown.Increment, out roundedTrackbar)
            );

            this.oTrackBar.Value = roundedTrackbar;
            this.ONosync = false;
        }

        private void oNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (true)
            {
                this.oTrackBar.Value = (int)(((double)this.oNumericUpDown.Value / this.DataStreamLength) * this.oTrackBar.Maximum);
            }
            this.Options.Offset = (long)this.oNumericUpDown.Value;

            if (this.autoRedrawCheckBox.Checked)
            {
                this.SoftRefresh();
            }
        }

        private bool ScalingNosync = false;
        private void scalingTrackBar_Scroll(object sender, EventArgs e)
        {
            this.ScalingNosync = true;
            this.scalingNumericUpDown.Value = this.scalingTrackBar.Value;
            this.ScalingNosync = false;
        }

        private void scalingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!this.ScalingNosync)
            {
                this.scalingTrackBar.Value = (int)this.scalingNumericUpDown.Value;
            }
            int oldPixelScaling = this.Options.PixelScaling;
            this.Options.PixelScaling = (int)this.scalingNumericUpDown.Value;

            this.PplNorefresh = true;
            var newPplValue = Math.Max(1m, Math.Floor((this.pplNumericUpDown.Value * oldPixelScaling) / this.Options.PixelScaling));
            this.pplNumericUpDown.Maximum = this.pplTrackBar.Maximum = Math.Max(1, this.Options.MaxImageWidth / this.Options.PixelScaling);
            this.pplNumericUpDown.Value = newPplValue;
            this.PplNorefresh = false;

            this.UpdateRoundings();
            if (this.autoRedrawCheckBox.Checked)
            {
                this.SoftRefresh();
            }
        }

        private bool NoSnapChangeEvent = false;
        private void SnapChangedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.NoSnapChangeEvent)
            {
                return;
            }

            this.UpdateRoundings();
        }

        private void hexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.oNumericUpDown.Hexadecimal = this.hexCheckBox.Checked;
        }

        private void pfComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Options.DPFormat = BitmapOperations.StringToDataPixelFormat(this.pfComboBox.Text);
            this.pixelSnapRadioButton.Enabled = (this.Options.DPFormat != BitmapOperations.DataPixelFormat.GRAYSCALE);
            if (!this.pixelSnapRadioButton.Enabled && this.pixelSnapRadioButton.Checked)
            {
                this.NoSnapChangeEvent = true;
                this.noSnapRadioButton.Checked = true;
                this.NoSnapChangeEvent = false;
            }

            this.UpdateRoundings();
            this.HardRefresh();
        }

        #region Picturebox events

        private void MainPictureBoxOnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 0)
            {
                return;
            }

            int actualDelta = e.Delta / SystemInformation.MouseWheelScrollDelta;

            this.UpdateRoundings();
            this.oNumericUpDown.Value = Math.Clamp(oNumericUpDown.Value + actualDelta * this.oNumericUpDown.Increment,
                0, this.oNumericUpDown.Maximum);
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.LastMouseY = e.Y;
            this.IsDraggingOnPicturebox = true;
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsDraggingOnPicturebox = false;
            this.LastMouseY = -1;
        }

        private bool IsDraggingOnPicturebox = false;
        private int LastMouseY = 0;
        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.IsDraggingOnPicturebox)
            {
                return;
            }

            int deltaPixels = -(e.Y - this.LastMouseY); // reversed: drag down => move up
            int deltaInScaledPixels = deltaPixels / this.Options.PixelScaling;

            if (deltaInScaledPixels != 0)
            {
                this.LastMouseY = e.Y;

                this.UpdateRoundings();
                this.oNumericUpDown.Value = Math.Clamp(oNumericUpDown.Value + deltaInScaledPixels * this.Options.PixelsPerLine * this.BytesPerPixel,
                    0, this.oNumericUpDown.Maximum);
            }
        }

        #endregion

        private void fitToViewButton_Click(object sender, EventArgs e)
        {
            int availableSpace = this.mainPictureBox.Width;
            int usablePixels = availableSpace / this.Options.PixelScaling;
            this.pplNumericUpDown.Value = usablePixels;
        }

        #endregion

        private void OpenFile(string path)
        {
            this.CleanupStream();

            this.oNumericUpDown.Value = 0;

            try
            {
                this.DataStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                this.DataStreamLength = this.DataStream.Length;
            }
            catch (IOException e)
            {
                MessageBox.Show($"Failed to open file. Error:\n\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CleanupStream();
                return;
            }

            this.FilePath = path;
            this.oNumericUpDown.Maximum = this.DataStreamLength;
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

            this.pplNumericUpDown.Maximum = this.pplTrackBar.Maximum = this.Options.MaxImageWidth / this.Options.PixelScaling;

            this.HardRefresh();
        }

        private void paletteEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.PaletteForm != null)
            {
                this.PaletteForm.BringToFront();
                return;
            }

            var form = new ColorPaletteForm();
            form.Closed += (_, _) =>
            {
                this.PaletteForm = null;
            };
            form.PaletteParsed += this.PaletteParsed;

            this.PaletteForm = form;
            form.Show(this);
        }

        private void PaletteParsed(CustomColorPalette palette)
        {
            if (this.mainPictureBox.Image.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                return;
            }

            var pbPalette = this.mainPictureBox.Image.Palette;
            palette.SetColorsToPalette(pbPalette);
            this.mainPictureBox.Image.Palette = pbPalette;

            this.mainPictureBox.Invalidate();
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

            int width = this.Options.PixelsPerLine * this.Options.PixelScaling;
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

        private void CleanupStream()
        {
            this.DataStream?.Dispose();
            this.DataStream = null;

            this.FilePath = null;
            this.DataStreamLength = 0;
        }

        private void DisposeStuff()
        {
            this.TheImage?.Dispose();
            this.CleanupStream();
        }
    }

    public class OptionValues
    {
        public int MaxImageWidth = 2048;
        public int MaxImageHeight = 1000;

        public int PixelsPerLine = 1000;
        public long Offset = 0;
        public int PixelScaling = 1;
        public BitmapOperations.DataPixelFormat DPFormat = BitmapOperations.StringToDataPixelFormat("RGB");
    }
}
