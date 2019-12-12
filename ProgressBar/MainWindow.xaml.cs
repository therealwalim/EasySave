using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;

namespace ProgressBar
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker m_oWorker;

        private ManualResetEvent locker = new ManualResetEvent(true);

        public MainWindow()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;


        }

        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //If it was cancelled midway
            if (e.Cancelled)
            {
                MessageBox.Show("Task Cancelled.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error while performing background operation.");
            }

            Start.IsEnabled = true;
            Stop.IsEnabled = false;
        }


        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here you play with the main UI thread
            progressBar1.Value = e.ProgressPercentage;
        }


        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            for (int i = 0; i < 100; i++)
            {
                locker.WaitOne();
                Thread.Sleep(100); //Our running task
                m_oWorker.ReportProgress(i);


                if (m_oWorker.CancellationPending)
                {
                    e.Cancel = true;
                    m_oWorker.ReportProgress(0);
                    return;
                }
            }
            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
        }


        private void Start_Click(object sender, EventArgs e)
        {
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
            Pause.IsEnabled = true;
            //Start the async operation here
            m_oWorker.RunWorkerAsync();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (m_oWorker.IsBusy)
            {
                //Stop the async operation here
                m_oWorker.CancelAsync();
                progressBar1.Value = 0;

            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {

            if (Pause.Content == "Pause")
            {
                locker.Reset();
                Pause.Content = "Resume";
            }
            else
            {
                locker.Set();
                Pause.Content = "Pause";
            }
        }
    }
}
