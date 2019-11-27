using Newtonsoft.Json;
using System;
using System.IO;
using System.Diagnostics;

namespace ProjetPrograSys
{
    class Program
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

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

            //// Verify if a Backup directory exist and create it if not
            //Logs.CreateDir(path, srcPath);

            //// Create a stopWatch object
            //Stopwatch stopWatch = new Stopwatch();

            //// Start the countdown
            //stopWatch.Start();
            //// Copy files from the source directory to the destination

            //// Progress bar
            ////Console.Write("Performing some task... ");
            ////using (var progress = new ProgressBar())
            ////{
            ////    for (int i = 0; i <= 100; i++)
            ////    {
            ////        progress.Report((double)i / 100);
            //Logs.Copy(path, srcPath); // Copy function
            ////    }
            ////}
            ////Console.WriteLine("Done.");

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
            //    FileSize = DirSize(new DirectoryInfo(srcPath)),
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
            //Logs.StoreJSON(strPath,MyJSON,strResultJson);

            //// Read JSON
            ////Logs.ReadJSON(strPath);
            ///

            Launcher display = new Launcher();
            
            // Start the application
            display.starter();

            Console.ReadLine();
        }
    }
}
