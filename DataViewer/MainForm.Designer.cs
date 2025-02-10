
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
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            paletteEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mainTLP = new System.Windows.Forms.TableLayoutPanel();
            controlsPanel = new System.Windows.Forms.Panel();
            scalingGroupBox = new System.Windows.Forms.GroupBox();
            scalingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            scalingTrackBar = new System.Windows.Forms.TrackBar();
            saveImportantButton = new System.Windows.Forms.Button();
            pfGroupGox = new System.Windows.Forms.GroupBox();
            pfComboBox = new System.Windows.Forms.ComboBox();
            oGroupBox = new System.Windows.Forms.GroupBox();
            lineSnapRadioButton = new System.Windows.Forms.RadioButton();
            pixelSnapRadioButton = new System.Windows.Forms.RadioButton();
            noSnapRadioButton = new System.Windows.Forms.RadioButton();
            hexCheckBox = new System.Windows.Forms.CheckBox();
            oTrackBar = new System.Windows.Forms.TrackBar();
            oNumericUpDown = new System.Windows.Forms.NumericUpDown();
            pplGroupBox = new System.Windows.Forms.GroupBox();
            pplNumericUpDown = new System.Windows.Forms.NumericUpDown();
            pplTrackBar = new System.Windows.Forms.TrackBar();
            saveAllButton = new System.Windows.Forms.Button();
            redrawButton = new System.Windows.Forms.Button();
            autoRedrawCheckBox = new System.Windows.Forms.CheckBox();
            mainPictureBox = new System.Windows.Forms.PictureBox();
            mainOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            mainMenuStrip.SuspendLayout();
            mainTLP.SuspendLayout();
            controlsPanel.SuspendLayout();
            scalingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scalingNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scalingTrackBar).BeginInit();
            pfGroupGox.SuspendLayout();
            oGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)oTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oNumericUpDown).BeginInit();
            pplGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pplNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pplTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, optionsToolStripMenuItem, paletteEditorToolStripMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(991, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            // 
            // paletteEditorToolStripMenuItem
            // 
            paletteEditorToolStripMenuItem.Name = "paletteEditorToolStripMenuItem";
            paletteEditorToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            paletteEditorToolStripMenuItem.Text = "Palette editor";
            paletteEditorToolStripMenuItem.Click += paletteEditorToolStripMenuItem_Click;
            // 
            // mainTLP
            // 
            mainTLP.ColumnCount = 2;
            mainTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            mainTLP.Controls.Add(controlsPanel, 1, 0);
            mainTLP.Controls.Add(mainPictureBox, 0, 0);
            mainTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTLP.Location = new System.Drawing.Point(0, 24);
            mainTLP.Name = "mainTLP";
            mainTLP.RowCount = 1;
            mainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTLP.Size = new System.Drawing.Size(991, 669);
            mainTLP.TabIndex = 1;
            // 
            // controlsPanel
            // 
            controlsPanel.Controls.Add(scalingGroupBox);
            controlsPanel.Controls.Add(saveImportantButton);
            controlsPanel.Controls.Add(pfGroupGox);
            controlsPanel.Controls.Add(oGroupBox);
            controlsPanel.Controls.Add(pplGroupBox);
            controlsPanel.Controls.Add(saveAllButton);
            controlsPanel.Controls.Add(redrawButton);
            controlsPanel.Controls.Add(autoRedrawCheckBox);
            controlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            controlsPanel.Location = new System.Drawing.Point(794, 3);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new System.Drawing.Size(194, 663);
            controlsPanel.TabIndex = 0;
            // 
            // scalingGroupBox
            // 
            scalingGroupBox.Controls.Add(scalingNumericUpDown);
            scalingGroupBox.Controls.Add(scalingTrackBar);
            scalingGroupBox.Location = new System.Drawing.Point(3, 291);
            scalingGroupBox.Name = "scalingGroupBox";
            scalingGroupBox.Size = new System.Drawing.Size(188, 100);
            scalingGroupBox.TabIndex = 15;
            scalingGroupBox.TabStop = false;
            scalingGroupBox.Text = "Pixel scaling";
            // 
            // scalingNumericUpDown
            // 
            scalingNumericUpDown.Location = new System.Drawing.Point(6, 22);
            scalingNumericUpDown.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            scalingNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            scalingNumericUpDown.Name = "scalingNumericUpDown";
            scalingNumericUpDown.Size = new System.Drawing.Size(79, 23);
            scalingNumericUpDown.TabIndex = 1;
            scalingNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            scalingNumericUpDown.ValueChanged += scalingNumericUpDown_ValueChanged;
            // 
            // scalingTrackBar
            // 
            scalingTrackBar.Location = new System.Drawing.Point(6, 51);
            scalingTrackBar.Maximum = 50;
            scalingTrackBar.Minimum = 1;
            scalingTrackBar.Name = "scalingTrackBar";
            scalingTrackBar.Size = new System.Drawing.Size(176, 45);
            scalingTrackBar.TabIndex = 2;
            scalingTrackBar.Value = 1;
            scalingTrackBar.Scroll += scalingTrackBar_Scroll;
            // 
            // saveImportantButton
            // 
            saveImportantButton.Location = new System.Drawing.Point(3, 519);
            saveImportantButton.Name = "saveImportantButton";
            saveImportantButton.Size = new System.Drawing.Size(188, 23);
            saveImportantButton.TabIndex = 14;
            saveImportantButton.Text = "Save (without borders)";
            saveImportantButton.UseVisualStyleBackColor = true;
            saveImportantButton.Click += saveImportantButton_Click;
            // 
            // pfGroupGox
            // 
            pfGroupGox.Controls.Add(pfComboBox);
            pfGroupGox.Location = new System.Drawing.Point(3, 397);
            pfGroupGox.Name = "pfGroupGox";
            pfGroupGox.Size = new System.Drawing.Size(188, 52);
            pfGroupGox.TabIndex = 13;
            pfGroupGox.TabStop = false;
            pfGroupGox.Text = "Pixel format";
            // 
            // pfComboBox
            // 
            pfComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            pfComboBox.FormattingEnabled = true;
            pfComboBox.Items.AddRange(new object[] { "Grayscale (using palette)", "RGB", "BGR", "RGBA", "BGRA", "ARGB", "ABGR" });
            pfComboBox.Location = new System.Drawing.Point(6, 22);
            pfComboBox.Name = "pfComboBox";
            pfComboBox.Size = new System.Drawing.Size(176, 23);
            pfComboBox.TabIndex = 7;
            pfComboBox.SelectedIndexChanged += pfComboBox_SelectedIndexChanged;
            // 
            // oGroupBox
            // 
            oGroupBox.Controls.Add(lineSnapRadioButton);
            oGroupBox.Controls.Add(pixelSnapRadioButton);
            oGroupBox.Controls.Add(noSnapRadioButton);
            oGroupBox.Controls.Add(hexCheckBox);
            oGroupBox.Controls.Add(oTrackBar);
            oGroupBox.Controls.Add(oNumericUpDown);
            oGroupBox.Location = new System.Drawing.Point(3, 109);
            oGroupBox.Name = "oGroupBox";
            oGroupBox.Size = new System.Drawing.Size(188, 176);
            oGroupBox.TabIndex = 12;
            oGroupBox.TabStop = false;
            oGroupBox.Text = "Offset";
            // 
            // lineSnapRadioButton
            // 
            lineSnapRadioButton.AutoSize = true;
            lineSnapRadioButton.Location = new System.Drawing.Point(6, 152);
            lineSnapRadioButton.Name = "lineSnapRadioButton";
            lineSnapRadioButton.Size = new System.Drawing.Size(92, 19);
            lineSnapRadioButton.TabIndex = 9;
            lineSnapRadioButton.TabStop = true;
            lineSnapRadioButton.Text = "Snap to lines";
            lineSnapRadioButton.UseVisualStyleBackColor = true;
            lineSnapRadioButton.CheckedChanged += SnapChangedRadioButton_CheckedChanged;
            // 
            // pixelSnapRadioButton
            // 
            pixelSnapRadioButton.AutoSize = true;
            pixelSnapRadioButton.Enabled = false;
            pixelSnapRadioButton.Location = new System.Drawing.Point(6, 127);
            pixelSnapRadioButton.Name = "pixelSnapRadioButton";
            pixelSnapRadioButton.Size = new System.Drawing.Size(98, 19);
            pixelSnapRadioButton.TabIndex = 8;
            pixelSnapRadioButton.TabStop = true;
            pixelSnapRadioButton.Text = "Snap to pixels";
            pixelSnapRadioButton.UseVisualStyleBackColor = true;
            pixelSnapRadioButton.CheckedChanged += SnapChangedRadioButton_CheckedChanged;
            // 
            // noSnapRadioButton
            // 
            noSnapRadioButton.AutoSize = true;
            noSnapRadioButton.Checked = true;
            noSnapRadioButton.Location = new System.Drawing.Point(6, 102);
            noSnapRadioButton.Name = "noSnapRadioButton";
            noSnapRadioButton.Size = new System.Drawing.Size(82, 19);
            noSnapRadioButton.TabIndex = 7;
            noSnapRadioButton.TabStop = true;
            noSnapRadioButton.Text = "Don't snap";
            noSnapRadioButton.UseVisualStyleBackColor = true;
            noSnapRadioButton.CheckedChanged += SnapChangedRadioButton_CheckedChanged;
            // 
            // hexCheckBox
            // 
            hexCheckBox.AutoSize = true;
            hexCheckBox.Checked = true;
            hexCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            hexCheckBox.Location = new System.Drawing.Point(91, 23);
            hexCheckBox.Name = "hexCheckBox";
            hexCheckBox.Size = new System.Drawing.Size(47, 19);
            hexCheckBox.TabIndex = 6;
            hexCheckBox.Text = "Hex";
            hexCheckBox.UseVisualStyleBackColor = true;
            hexCheckBox.CheckedChanged += hexCheckBox_CheckedChanged;
            // 
            // oTrackBar
            // 
            oTrackBar.Location = new System.Drawing.Point(6, 51);
            oTrackBar.Maximum = 1000;
            oTrackBar.Name = "oTrackBar";
            oTrackBar.Size = new System.Drawing.Size(176, 45);
            oTrackBar.TabIndex = 5;
            oTrackBar.Scroll += oTrackBar_Scroll;
            // 
            // oNumericUpDown
            // 
            oNumericUpDown.Hexadecimal = true;
            oNumericUpDown.Location = new System.Drawing.Point(6, 22);
            oNumericUpDown.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            oNumericUpDown.Name = "oNumericUpDown";
            oNumericUpDown.Size = new System.Drawing.Size(79, 23);
            oNumericUpDown.TabIndex = 4;
            oNumericUpDown.ValueChanged += oNumericUpDown_ValueChanged;
            // 
            // pplGroupBox
            // 
            pplGroupBox.Controls.Add(pplNumericUpDown);
            pplGroupBox.Controls.Add(pplTrackBar);
            pplGroupBox.Location = new System.Drawing.Point(3, 3);
            pplGroupBox.Name = "pplGroupBox";
            pplGroupBox.Size = new System.Drawing.Size(188, 100);
            pplGroupBox.TabIndex = 11;
            pplGroupBox.TabStop = false;
            pplGroupBox.Text = "Pixels per line";
            // 
            // pplNumericUpDown
            // 
            pplNumericUpDown.Location = new System.Drawing.Point(6, 22);
            pplNumericUpDown.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            pplNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pplNumericUpDown.Name = "pplNumericUpDown";
            pplNumericUpDown.Size = new System.Drawing.Size(79, 23);
            pplNumericUpDown.TabIndex = 1;
            pplNumericUpDown.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            pplNumericUpDown.ValueChanged += pplNumericUpDown_ValueChanged;
            // 
            // pplTrackBar
            // 
            pplTrackBar.Location = new System.Drawing.Point(6, 51);
            pplTrackBar.Maximum = 2048;
            pplTrackBar.Minimum = 1;
            pplTrackBar.Name = "pplTrackBar";
            pplTrackBar.Size = new System.Drawing.Size(176, 45);
            pplTrackBar.TabIndex = 2;
            pplTrackBar.Value = 1000;
            pplTrackBar.Scroll += pplTrackBar_Scroll;
            // 
            // saveAllButton
            // 
            saveAllButton.Location = new System.Drawing.Point(3, 548);
            saveAllButton.Name = "saveAllButton";
            saveAllButton.Size = new System.Drawing.Size(188, 23);
            saveAllButton.TabIndex = 10;
            saveAllButton.Text = "Save whole image";
            saveAllButton.UseVisualStyleBackColor = true;
            saveAllButton.Click += saveAllButton_Click;
            // 
            // redrawButton
            // 
            redrawButton.Location = new System.Drawing.Point(3, 490);
            redrawButton.Name = "redrawButton";
            redrawButton.Size = new System.Drawing.Size(91, 23);
            redrawButton.TabIndex = 9;
            redrawButton.Text = "Redraw";
            redrawButton.UseVisualStyleBackColor = true;
            redrawButton.Click += redrawButton_Click;
            // 
            // autoRedrawCheckBox
            // 
            autoRedrawCheckBox.AutoSize = true;
            autoRedrawCheckBox.Checked = true;
            autoRedrawCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            autoRedrawCheckBox.Location = new System.Drawing.Point(100, 493);
            autoRedrawCheckBox.Name = "autoRedrawCheckBox";
            autoRedrawCheckBox.Size = new System.Drawing.Size(91, 19);
            autoRedrawCheckBox.TabIndex = 8;
            autoRedrawCheckBox.Text = "Auto redraw";
            autoRedrawCheckBox.UseVisualStyleBackColor = true;
            autoRedrawCheckBox.CheckedChanged += autoRedrawCheckBox_CheckedChanged;
            // 
            // mainPictureBox
            // 
            mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            mainPictureBox.Location = new System.Drawing.Point(3, 3);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new System.Drawing.Size(785, 663);
            mainPictureBox.TabIndex = 1;
            mainPictureBox.TabStop = false;
            mainPictureBox.MouseDown += mainPictureBox_MouseDown;
            mainPictureBox.MouseMove += mainPictureBox_MouseMove;
            mainPictureBox.MouseUp += mainPictureBox_MouseUp;
            // 
            // mainOpenFileDialog
            // 
            mainOpenFileDialog.Filter = "All files|*.*";
            mainOpenFileDialog.ReadOnlyChecked = true;
            mainOpenFileDialog.Title = "Open file";
            // 
            // saveOpenFileDialog
            // 
            saveOpenFileDialog.CheckFileExists = false;
            saveOpenFileDialog.CheckPathExists = false;
            saveOpenFileDialog.DefaultExt = "png";
            saveOpenFileDialog.FileName = "view.png";
            saveOpenFileDialog.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            saveOpenFileDialog.Title = "Save view";
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(991, 693);
            Controls.Add(mainTLP);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Name = "MainForm";
            Text = "Data Viewer";
            Load += MainForm_Load;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            mainTLP.ResumeLayout(false);
            controlsPanel.ResumeLayout(false);
            controlsPanel.PerformLayout();
            scalingGroupBox.ResumeLayout(false);
            scalingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scalingNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)scalingTrackBar).EndInit();
            pfGroupGox.ResumeLayout(false);
            oGroupBox.ResumeLayout(false);
            oGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)oTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)oNumericUpDown).EndInit();
            pplGroupBox.ResumeLayout(false);
            pplGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pplNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pplTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

