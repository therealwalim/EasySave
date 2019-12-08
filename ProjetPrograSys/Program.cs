using Newtonsoft.Json;
using System;
using System.IO;
using System.Diagnostics;

namespace ProjetPrograSys
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Blue;

            //Console.WriteLine("Enter the work ID : ");
            //string ID = Console.ReadLine();

            //// Create a DateTime object to catch the time
            //DateTime now = DateTime.Now;
            //string dateT = now.ToString("dd MMMM yyyy hh:mm:ss tt");

            //string path = @"C:\Users\ASUS\Desktop\Backup";
            //Console.WriteLine("Enter the name of the task : ");

            //// Catch the source file
            //string task = Console.ReadLine();
            //Console.WriteLine("Specify the path : ");

            //string srcPathDir = Console.ReadLine();
            //string srcPath = @"C:\Users\ASUS\Desktop\" + srcPathDir;
            //Console.WriteLine("You choosed this path : " + srcPath);


            //// Object creation
            //StoreLogs Logs = new StoreLogs();

            //// Calculate the size of the source path
            //long size = Logs.DirSize(new DirectoryInfo(srcPath));

            //// Verify if a Backup directory exist and create it if not
            //Logs.CreateDir(path, srcPath);

            //// Create a stopWatch object
            //Stopwatch stopWatch = new Stopwatch();

            //// Start the countdown
            //stopWatch.Start();
            //// Copy files from the source directory to the destination

            //// Progress bar
            //Console.Write("Performing some task... ");
            //using (var progress = new ProgressBar())
            //{
            //    for (int i = 0; i <= 100; i++)
            //    {
            //        progress.Report((double)i / 100);
            //        Logs.Copy(path, srcPath); // Copy function
            //    }
            //}
            //Console.WriteLine("Done.");

            //// Stop the countdown
            //stopWatch.Stop();

            //// Get the elapsed time as a TimeSpan value.
            //TimeSpan ts = stopWatch.Elapsed;

            //// Create an object and store properties
            //StoreLogs Log = new StoreLogs()
            //{
            //    Id = ID,
            //    DateTime = dateT,
            //    TaskName = task,
            //    SrcAddress = srcPath,
            //    DstAddress = path,
            //    FileSize = size,
            //    DelayTransfer = ts.Milliseconds,
            //};

            //// Record JSON data in the variable
            //string strResultJson = JsonConvert.SerializeObject(Log);

            //// Show the JSON Data
            //// Console.WriteLine(strResultJson);

            //// Write JSON Data in another file

            //string MyJSON = null;
            //string strPath = @"C:\Users\ASUS\Desktop\Backup\logs\log.json";

            //// Store to the right JSON FORMAT
            //Logs.StoreJSON(strPath, MyJSON, strResultJson);

            //// Read JSON
            ////Logs.ReadJSON(strPath);

            //Launcher display = new Launcher();

            //// Start the application
            ////display.starter();


            //* Create your Process
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\ASUS\Desktop\C# Repository\EasySave\CryptoSoft\bin\Debug\netcoreapp3.0\CryptoSoft.exe";
            process.StartInfo.Arguments = @"source C:\Users\ASUS\Desktop\Root\testant.txt destination C:\Users\ASUS\Desktop\Backup\testant.txt";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            //* Start process
            process.Start();
            //* Read the other one synchronously
            string output = process.StandardOutput.ReadToEnd();
            using (StreamWriter file = new StreamWriter(@"D:\Resultat.txt", true))
            {
                file.WriteLine(output);
            }
                process.WaitForExit();
        }
    }
}
