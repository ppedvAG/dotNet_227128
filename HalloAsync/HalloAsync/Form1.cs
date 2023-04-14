namespace HalloAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    progressBar1.Value = i;
                    Thread.Sleep(300);
                }
            });

        }
    }
}