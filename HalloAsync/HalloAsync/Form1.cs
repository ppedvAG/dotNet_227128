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
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(300);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    //progressBar1.Value = i;
                    progressBar1.Invoke(new Action(() => { progressBar1.Value = i; }));
                    Thread.Sleep(300);
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            button3.Enabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Factory.StartNew(() => progressBar1.Value = i, CancellationToken.None, TaskCreationOptions.None, ts);
                    Thread.Sleep(30);
                }
            }).ContinueWith(t => button3.Enabled = true, CancellationToken.None, TaskContinuationOptions.None, ts);

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;

            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;

                await Task.Delay(30);
            }

            button3.Enabled = true;
        }

        private long AlteLangesameFunc(int zahl)
        {
            Thread.Sleep(5000);
            return 923847 * zahl;
        }

        
        private ValueTask<long> AlteLangesameFuncAsync(int zahl) 
        {
            return Task.Run(() => AlteLangesameFunc(zahl));
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"OLD Func: {AlteLangesameFunc(16)}");
            MessageBox.Show($"OLD Func: {await AlteLangesameFuncAsync(16)}");
        }
    }
}