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
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new welcome();
            Progress.Content = new progress();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        //{
        //    var dialog = new System.Windows.Forms.FolderBrowserDialog();
        //    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
        //    srcPath.Text = dialog.SelectedPath;

        //}

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void addnewtask_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new addnewtask();
        }
        private void launchtask_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new specifictask();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new specifictask();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new displaytasklist();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new encrypt();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new welcome();
        }


    }
}
