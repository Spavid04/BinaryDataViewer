using System.Windows.Forms;

namespace DataViewer
{
    public partial class OptionsForm : Form
    {
        private readonly OptionValues Options;

        public OptionsForm(OptionValues options)
        {
            InitializeComponent();

            //todo "grayscale" color palette

            this.Options = options;
            this.InitializeValues();
        }

        private void InitializeValues()
        {
            this.maxWidthNumericUpDown.Value = this.Options.MaxImageWidth;
            this.maxHeightNumericUpDown.Value = this.Options.MaxImageHeight;
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Options.MaxImageWidth = (int)this.maxWidthNumericUpDown.Value;
            this.Options.MaxImageHeight = (int)this.maxHeightNumericUpDown.Value;
        }
    }
}
