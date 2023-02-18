
namespace DataViewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paletteEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTLP = new System.Windows.Forms.TableLayoutPanel();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.scalingGroupBox = new System.Windows.Forms.GroupBox();
            this.scalingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scalingTrackBar = new System.Windows.Forms.TrackBar();
            this.saveImportantButton = new System.Windows.Forms.Button();
            this.pfGroupGox = new System.Windows.Forms.GroupBox();
            this.pfComboBox = new System.Windows.Forms.ComboBox();
            this.oGroupBox = new System.Windows.Forms.GroupBox();
            this.lineSnapRadioButton = new System.Windows.Forms.RadioButton();
            this.pixelSnapRadioButton = new System.Windows.Forms.RadioButton();
            this.noSnapRadioButton = new System.Windows.Forms.RadioButton();
            this.hexCheckBox = new System.Windows.Forms.CheckBox();
            this.oTrackBar = new System.Windows.Forms.TrackBar();
            this.oNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pplGroupBox = new System.Windows.Forms.GroupBox();
            this.pplNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pplTrackBar = new System.Windows.Forms.TrackBar();
            this.saveAllButton = new System.Windows.Forms.Button();
            this.redrawButton = new System.Windows.Forms.Button();
            this.autoRedrawCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.mainOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainMenuStrip.SuspendLayout();
            this.mainTLP.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.scalingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBar)).BeginInit();
            this.pfGroupGox.SuspendLayout();
            this.oGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oNumericUpDown)).BeginInit();
            this.pplGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pplNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pplTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.paletteEditorToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(991, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // paletteEditorToolStripMenuItem
            // 
            this.paletteEditorToolStripMenuItem.Name = "paletteEditorToolStripMenuItem";
            this.paletteEditorToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.paletteEditorToolStripMenuItem.Text = "Palette editor";
            this.paletteEditorToolStripMenuItem.Click += new System.EventHandler(this.paletteEditorToolStripMenuItem_Click);
            // 
            // mainTLP
            // 
            this.mainTLP.ColumnCount = 2;
            this.mainTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.mainTLP.Controls.Add(this.controlsPanel, 1, 0);
            this.mainTLP.Controls.Add(this.mainPictureBox, 0, 0);
            this.mainTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTLP.Location = new System.Drawing.Point(0, 24);
            this.mainTLP.Name = "mainTLP";
            this.mainTLP.RowCount = 1;
            this.mainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTLP.Size = new System.Drawing.Size(991, 669);
            this.mainTLP.TabIndex = 1;
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.scalingGroupBox);
            this.controlsPanel.Controls.Add(this.saveImportantButton);
            this.controlsPanel.Controls.Add(this.pfGroupGox);
            this.controlsPanel.Controls.Add(this.oGroupBox);
            this.controlsPanel.Controls.Add(this.pplGroupBox);
            this.controlsPanel.Controls.Add(this.saveAllButton);
            this.controlsPanel.Controls.Add(this.redrawButton);
            this.controlsPanel.Controls.Add(this.autoRedrawCheckBox);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsPanel.Location = new System.Drawing.Point(794, 3);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(194, 663);
            this.controlsPanel.TabIndex = 0;
            // 
            // scalingGroupBox
            // 
            this.scalingGroupBox.Controls.Add(this.scalingNumericUpDown);
            this.scalingGroupBox.Controls.Add(this.scalingTrackBar);
            this.scalingGroupBox.Location = new System.Drawing.Point(3, 291);
            this.scalingGroupBox.Name = "scalingGroupBox";
            this.scalingGroupBox.Size = new System.Drawing.Size(188, 100);
            this.scalingGroupBox.TabIndex = 15;
            this.scalingGroupBox.TabStop = false;
            this.scalingGroupBox.Text = "Pixel scaling";
            // 
            // scalingNumericUpDown
            // 
            this.scalingNumericUpDown.Location = new System.Drawing.Point(6, 22);
            this.scalingNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.scalingNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scalingNumericUpDown.Name = "scalingNumericUpDown";
            this.scalingNumericUpDown.Size = new System.Drawing.Size(79, 23);
            this.scalingNumericUpDown.TabIndex = 1;
            this.scalingNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scalingNumericUpDown.ValueChanged += new System.EventHandler(this.scalingNumericUpDown_ValueChanged);
            // 
            // scalingTrackBar
            // 
            this.scalingTrackBar.Location = new System.Drawing.Point(6, 51);
            this.scalingTrackBar.Maximum = 50;
            this.scalingTrackBar.Minimum = 1;
            this.scalingTrackBar.Name = "scalingTrackBar";
            this.scalingTrackBar.Size = new System.Drawing.Size(176, 45);
            this.scalingTrackBar.TabIndex = 2;
            this.scalingTrackBar.Value = 1;
            this.scalingTrackBar.Scroll += new System.EventHandler(this.scalingTrackBar_Scroll);
            // 
            // saveImportantButton
            // 
            this.saveImportantButton.Location = new System.Drawing.Point(3, 519);
            this.saveImportantButton.Name = "saveImportantButton";
            this.saveImportantButton.Size = new System.Drawing.Size(188, 23);
            this.saveImportantButton.TabIndex = 14;
            this.saveImportantButton.Text = "Save relevant image";
            this.saveImportantButton.UseVisualStyleBackColor = true;
            this.saveImportantButton.Click += new System.EventHandler(this.saveImportantButton_Click);
            // 
            // pfGroupGox
            // 
            this.pfGroupGox.Controls.Add(this.pfComboBox);
            this.pfGroupGox.Location = new System.Drawing.Point(3, 397);
            this.pfGroupGox.Name = "pfGroupGox";
            this.pfGroupGox.Size = new System.Drawing.Size(188, 52);
            this.pfGroupGox.TabIndex = 13;
            this.pfGroupGox.TabStop = false;
            this.pfGroupGox.Text = "Pixel format";
            // 
            // pfComboBox
            // 
            this.pfComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pfComboBox.FormattingEnabled = true;
            this.pfComboBox.Items.AddRange(new object[] {
            "Grayscale (using palette)",
            "RGB",
            "BGR",
            "RGBA",
            "BGRA",
            "ARGB",
            "ABGR"});
            this.pfComboBox.Location = new System.Drawing.Point(6, 22);
            this.pfComboBox.Name = "pfComboBox";
            this.pfComboBox.Size = new System.Drawing.Size(176, 23);
            this.pfComboBox.TabIndex = 7;
            this.pfComboBox.SelectedIndexChanged += new System.EventHandler(this.pfComboBox_SelectedIndexChanged);
            // 
            // oGroupBox
            // 
            this.oGroupBox.Controls.Add(this.lineSnapRadioButton);
            this.oGroupBox.Controls.Add(this.pixelSnapRadioButton);
            this.oGroupBox.Controls.Add(this.noSnapRadioButton);
            this.oGroupBox.Controls.Add(this.hexCheckBox);
            this.oGroupBox.Controls.Add(this.oTrackBar);
            this.oGroupBox.Controls.Add(this.oNumericUpDown);
            this.oGroupBox.Location = new System.Drawing.Point(3, 109);
            this.oGroupBox.Name = "oGroupBox";
            this.oGroupBox.Size = new System.Drawing.Size(188, 176);
            this.oGroupBox.TabIndex = 12;
            this.oGroupBox.TabStop = false;
            this.oGroupBox.Text = "Offset";
            // 
            // lineSnapRadioButton
            // 
            this.lineSnapRadioButton.AutoSize = true;
            this.lineSnapRadioButton.Location = new System.Drawing.Point(6, 152);
            this.lineSnapRadioButton.Name = "lineSnapRadioButton";
            this.lineSnapRadioButton.Size = new System.Drawing.Size(92, 19);
            this.lineSnapRadioButton.TabIndex = 9;
            this.lineSnapRadioButton.TabStop = true;
            this.lineSnapRadioButton.Text = "Snap to lines";
            this.lineSnapRadioButton.UseVisualStyleBackColor = true;
            this.lineSnapRadioButton.CheckedChanged += new System.EventHandler(this.SnapChangedRadioButton_CheckedChanged);
            // 
            // pixelSnapRadioButton
            // 
            this.pixelSnapRadioButton.AutoSize = true;
            this.pixelSnapRadioButton.Location = new System.Drawing.Point(6, 127);
            this.pixelSnapRadioButton.Name = "pixelSnapRadioButton";
            this.pixelSnapRadioButton.Size = new System.Drawing.Size(98, 19);
            this.pixelSnapRadioButton.TabIndex = 8;
            this.pixelSnapRadioButton.TabStop = true;
            this.pixelSnapRadioButton.Text = "Snap to pixels";
            this.pixelSnapRadioButton.UseVisualStyleBackColor = true;
            this.pixelSnapRadioButton.CheckedChanged += new System.EventHandler(this.SnapChangedRadioButton_CheckedChanged);
            // 
            // noSnapRadioButton
            // 
            this.noSnapRadioButton.AutoSize = true;
            this.noSnapRadioButton.Checked = true;
            this.noSnapRadioButton.Location = new System.Drawing.Point(6, 102);
            this.noSnapRadioButton.Name = "noSnapRadioButton";
            this.noSnapRadioButton.Size = new System.Drawing.Size(82, 19);
            this.noSnapRadioButton.TabIndex = 7;
            this.noSnapRadioButton.TabStop = true;
            this.noSnapRadioButton.Text = "Don\'t snap";
            this.noSnapRadioButton.UseVisualStyleBackColor = true;
            this.noSnapRadioButton.CheckedChanged += new System.EventHandler(this.SnapChangedRadioButton_CheckedChanged);
            // 
            // hexCheckBox
            // 
            this.hexCheckBox.AutoSize = true;
            this.hexCheckBox.Checked = true;
            this.hexCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hexCheckBox.Location = new System.Drawing.Point(91, 23);
            this.hexCheckBox.Name = "hexCheckBox";
            this.hexCheckBox.Size = new System.Drawing.Size(47, 19);
            this.hexCheckBox.TabIndex = 6;
            this.hexCheckBox.Text = "Hex";
            this.hexCheckBox.UseVisualStyleBackColor = true;
            this.hexCheckBox.CheckedChanged += new System.EventHandler(this.hexCheckBox_CheckedChanged);
            // 
            // oTrackBar
            // 
            this.oTrackBar.Location = new System.Drawing.Point(6, 51);
            this.oTrackBar.Maximum = 1000;
            this.oTrackBar.Name = "oTrackBar";
            this.oTrackBar.Size = new System.Drawing.Size(176, 45);
            this.oTrackBar.TabIndex = 5;
            this.oTrackBar.Scroll += new System.EventHandler(this.oTrackBar_Scroll);
            // 
            // oNumericUpDown
            // 
            this.oNumericUpDown.Hexadecimal = true;
            this.oNumericUpDown.Location = new System.Drawing.Point(6, 22);
            this.oNumericUpDown.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.oNumericUpDown.Name = "oNumericUpDown";
            this.oNumericUpDown.Size = new System.Drawing.Size(79, 23);
            this.oNumericUpDown.TabIndex = 4;
            this.oNumericUpDown.ValueChanged += new System.EventHandler(this.oNumericUpDown_ValueChanged);
            // 
            // pplGroupBox
            // 
            this.pplGroupBox.Controls.Add(this.pplNumericUpDown);
            this.pplGroupBox.Controls.Add(this.pplTrackBar);
            this.pplGroupBox.Location = new System.Drawing.Point(3, 3);
            this.pplGroupBox.Name = "pplGroupBox";
            this.pplGroupBox.Size = new System.Drawing.Size(188, 100);
            this.pplGroupBox.TabIndex = 11;
            this.pplGroupBox.TabStop = false;
            this.pplGroupBox.Text = "Pixels per line";
            // 
            // pplNumericUpDown
            // 
            this.pplNumericUpDown.Location = new System.Drawing.Point(6, 22);
            this.pplNumericUpDown.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.pplNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pplNumericUpDown.Name = "pplNumericUpDown";
            this.pplNumericUpDown.Size = new System.Drawing.Size(79, 23);
            this.pplNumericUpDown.TabIndex = 1;
            this.pplNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pplNumericUpDown.ValueChanged += new System.EventHandler(this.pplNumericUpDown_ValueChanged);
            // 
            // pplTrackBar
            // 
            this.pplTrackBar.Location = new System.Drawing.Point(6, 51);
            this.pplTrackBar.Maximum = 2048;
            this.pplTrackBar.Minimum = 1;
            this.pplTrackBar.Name = "pplTrackBar";
            this.pplTrackBar.Size = new System.Drawing.Size(176, 45);
            this.pplTrackBar.TabIndex = 2;
            this.pplTrackBar.Value = 1000;
            this.pplTrackBar.Scroll += new System.EventHandler(this.pplTrackBar_Scroll);
            // 
            // saveAllButton
            // 
            this.saveAllButton.Location = new System.Drawing.Point(3, 548);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(188, 23);
            this.saveAllButton.TabIndex = 10;
            this.saveAllButton.Text = "Save whole image";
            this.saveAllButton.UseVisualStyleBackColor = true;
            this.saveAllButton.Click += new System.EventHandler(this.saveAllButton_Click);
            // 
            // redrawButton
            // 
            this.redrawButton.Location = new System.Drawing.Point(3, 490);
            this.redrawButton.Name = "redrawButton";
            this.redrawButton.Size = new System.Drawing.Size(91, 23);
            this.redrawButton.TabIndex = 9;
            this.redrawButton.Text = "Redraw";
            this.redrawButton.UseVisualStyleBackColor = true;
            this.redrawButton.Click += new System.EventHandler(this.redrawButton_Click);
            // 
            // autoRedrawCheckBox
            // 
            this.autoRedrawCheckBox.AutoSize = true;
            this.autoRedrawCheckBox.Checked = true;
            this.autoRedrawCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRedrawCheckBox.Location = new System.Drawing.Point(100, 493);
            this.autoRedrawCheckBox.Name = "autoRedrawCheckBox";
            this.autoRedrawCheckBox.Size = new System.Drawing.Size(91, 19);
            this.autoRedrawCheckBox.TabIndex = 8;
            this.autoRedrawCheckBox.Text = "Auto redraw";
            this.autoRedrawCheckBox.UseVisualStyleBackColor = true;
            this.autoRedrawCheckBox.CheckedChanged += new System.EventHandler(this.autoRedrawCheckBox_CheckedChanged);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(785, 663);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            // 
            // mainOpenFileDialog
            // 
            this.mainOpenFileDialog.Filter = "All files|*.*";
            this.mainOpenFileDialog.ReadOnlyChecked = true;
            this.mainOpenFileDialog.Title = "Open file";
            // 
            // saveOpenFileDialog
            // 
            this.saveOpenFileDialog.CheckFileExists = false;
            this.saveOpenFileDialog.CheckPathExists = false;
            this.saveOpenFileDialog.DefaultExt = "png";
            this.saveOpenFileDialog.FileName = "view.png";
            this.saveOpenFileDialog.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            this.saveOpenFileDialog.Title = "Save view";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 693);
            this.Controls.Add(this.mainTLP);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Data Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTLP.ResumeLayout(false);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.scalingGroupBox.ResumeLayout(false);
            this.scalingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBar)).EndInit();
            this.pfGroupGox.ResumeLayout(false);
            this.oGroupBox.ResumeLayout(false);
            this.oGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oNumericUpDown)).EndInit();
            this.pplGroupBox.ResumeLayout(false);
            this.pplGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pplNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pplTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTLP;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.ComboBox pfComboBox;
        private System.Windows.Forms.TrackBar oTrackBar;
        private System.Windows.Forms.NumericUpDown oNumericUpDown;
        private System.Windows.Forms.TrackBar pplTrackBar;
        private System.Windows.Forms.NumericUpDown pplNumericUpDown;
        private System.Windows.Forms.Button redrawButton;
        private System.Windows.Forms.CheckBox autoRedrawCheckBox;
        private System.Windows.Forms.OpenFileDialog mainOpenFileDialog;
        private System.Windows.Forms.Button saveAllButton;
        private System.Windows.Forms.GroupBox pfGroupGox;
        private System.Windows.Forms.GroupBox oGroupBox;
        private System.Windows.Forms.GroupBox pplGroupBox;
        private System.Windows.Forms.CheckBox hexCheckBox;
        private System.Windows.Forms.RadioButton lineSnapRadioButton;
        private System.Windows.Forms.RadioButton pixelSnapRadioButton;
        private System.Windows.Forms.RadioButton noSnapRadioButton;
        private System.Windows.Forms.OpenFileDialog saveOpenFileDialog;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button saveImportantButton;
        private System.Windows.Forms.ToolStripMenuItem paletteEditorToolStripMenuItem;
        private System.Windows.Forms.GroupBox scalingGroupBox;
        private System.Windows.Forms.NumericUpDown scalingNumericUpDown;
        private System.Windows.Forms.TrackBar scalingTrackBar;
    }
}

