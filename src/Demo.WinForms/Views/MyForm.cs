namespace Demo.WinForms.Views
{
    internal partial class MyForm : MyFormBase, IMyView
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Presenter.ButtonWasClicked();
        }

        public string TextBoxText
        {
            get { return textBox1.Text; }
        }

        public string LabelText
        {
            set { label1.Text = value; }
        }
    }
}
