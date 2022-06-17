
namespace DataViewer
{
    partial class OptionsForm
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
            this.mainTLP = new System.Windows.Forms.TableLayoutPanel();
            this.widthGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mainTLP.SuspendLayout();
            this.widthGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTLP
            // 
            this.mainTLP.ColumnCount = 2;
            this.mainTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTLP.Controls.Add(this.widthGroupBox, 0, 0);
            this.mainTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTLP.Location = new System.Drawing.Point(0, 0);
            this.mainTLP.Name = "mainTLP";
            this.mainTLP.RowCount = 2;
            this.mainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTLP.Size = new System.Drawing.Size(323, 211);
            this.mainTLP.TabIndex = 0;
            // 
            // widthGroupBox
            // 
            this.widthGroupBox.AutoSize = true;
            this.widthGroupBox.Controls.Add(this.label4);
            this.widthGroupBox.Controls.Add(this.label3);
            this.widthGroupBox.Controls.Add(this.label2);
            this.widthGroupBox.Controls.Add(this.maxHeightNumericUpDown);
            this.widthGroupBox.Controls.Add(this.label1);
            this.widthGroupBox.Controls.Add(this.maxWidthNumericUpDown);
            this.widthGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.widthGroupBox.Location = new System.Drawing.Point(3, 3);
            this.widthGroupBox.Name = "widthGroupBox";
            this.widthGroupBox.Size = new System.Drawing.Size(144, 96);
            this.widthGroupBox.TabIndex = 0;
            this.widthGroupBox.TabStop = false;
            this.widthGroupBox.Text = "Max Image Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "px";
            // 
            // maxWidthNumericUpDown
            // 
            this.maxWidthNumericUpDown.Location = new System.Drawing.Point(32, 22);
            this.maxWidthNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.maxWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxWidthNumericUpDown.Name = "maxWidthNumericUpDown";
            this.maxWidthNumericUpDown.Size = new System.Drawing.Size(80, 23);
            this.maxWidthNumericUpDown.TabIndex = 0;
            this.maxWidthNumericUpDown.Tag = "";
            this.maxWidthNumericUpDown.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // maxHeightNumericUpDown
            // 
            this.maxHeightNumericUpDown.Location = new System.Drawing.Point(32, 51);
            this.maxHeightNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.maxHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxHeightNumericUpDown.Name = "maxHeightNumericUpDown";
            this.maxHeightNumericUpDown.Size = new System.Drawing.Size(80, 23);
            this.maxHeightNumericUpDown.TabIndex = 2;
            this.maxHeightNumericUpDown.Tag = "";
            this.maxHeightNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "px";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "w:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "h:";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 211);
            this.Controls.Add(this.mainTLP);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.mainTLP.ResumeLayout(false);
            this.mainTLP.PerformLayout();
            this.widthGroupBox.ResumeLayout(false);
            this.widthGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTLP;
        private System.Windows.Forms.GroupBox widthGroupBox;
        private System.Windows.Forms.NumericUpDown maxWidthNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxHeightNumericUpDown;
    }
}