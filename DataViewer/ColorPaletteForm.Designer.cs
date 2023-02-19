
namespace DataViewer
{
    partial class ColorPaletteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPaletteForm));
            this.colorPaletteTLP = new System.Windows.Forms.TableLayoutPanel();
            this.colorPaletteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.palettePictureBox = new System.Windows.Forms.PictureBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.colorPaletteTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palettePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // colorPaletteTLP
            // 
            this.colorPaletteTLP.ColumnCount = 2;
            this.colorPaletteTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94F));
            this.colorPaletteTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.colorPaletteTLP.Controls.Add(this.colorPaletteRichTextBox, 0, 0);
            this.colorPaletteTLP.Controls.Add(this.palettePictureBox, 1, 0);
            this.colorPaletteTLP.Controls.Add(this.statusLabel, 0, 1);
            this.colorPaletteTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPaletteTLP.Location = new System.Drawing.Point(0, 0);
            this.colorPaletteTLP.Name = "colorPaletteTLP";
            this.colorPaletteTLP.RowCount = 2;
            this.colorPaletteTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.colorPaletteTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.colorPaletteTLP.Size = new System.Drawing.Size(385, 438);
            this.colorPaletteTLP.TabIndex = 0;
            // 
            // colorPaletteRichTextBox
            // 
            this.colorPaletteRichTextBox.DetectUrls = false;
            this.colorPaletteRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPaletteRichTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorPaletteRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.colorPaletteRichTextBox.Name = "colorPaletteRichTextBox";
            this.colorPaletteRichTextBox.Size = new System.Drawing.Size(355, 382);
            this.colorPaletteRichTextBox.TabIndex = 0;
            this.colorPaletteRichTextBox.Text = resources.GetString("colorPaletteRichTextBox.Text");
            this.colorPaletteRichTextBox.WordWrap = false;
            // 
            // palettePictureBox
            // 
            this.palettePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palettePictureBox.Location = new System.Drawing.Point(364, 3);
            this.palettePictureBox.Name = "palettePictureBox";
            this.palettePictureBox.Size = new System.Drawing.Size(18, 382);
            this.palettePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.palettePictureBox.TabIndex = 1;
            this.palettePictureBox.TabStop = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Location = new System.Drawing.Point(3, 388);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(355, 50);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "OK";
            // 
            // ColorPaletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 438);
            this.Controls.Add(this.colorPaletteTLP);
            this.MinimizeBox = false;
            this.Name = "ColorPaletteForm";
            this.Text = "Color Palette editor";
            this.Resize += new System.EventHandler(this.ColorPaletteForm_Resize);
            this.colorPaletteTLP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palettePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel colorPaletteTLP;
        private System.Windows.Forms.RichTextBox colorPaletteRichTextBox;
        private System.Windows.Forms.PictureBox palettePictureBox;
        private System.Windows.Forms.Label statusLabel;
    }
}