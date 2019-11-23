using Newtonsoft.Json;
using System;
using System.IO;

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

        public static void Copy(string path, string srcPath)
        {
            var diSource = new DirectoryInfo(srcPath);
            var diTarget = new DirectoryInfo(path);

            CopyAll(diSource, diTarget);
            Console.WriteLine(srcPath+path);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        static void Main(string[] args)
        {      
            DateTime now = DateTime.Now;
            string dateT = now.ToString("dd MMMM yyyy hh:mm:ss tt");

            string path = @"C:\Users\ASUS\Desktop\Backup";
            Console.WriteLine("Entrez le nom de la tâche : ");

            string task = Console.ReadLine();
            Console.WriteLine("Veuillez spécifier le chemin");
            
            string srcPathDir = Console.ReadLine();
            string srcPath = @"C:\Users\ASUS\Desktop\"+srcPathDir;
            Console.WriteLine("Vous avez choisi le chemin : " + srcPath);

            StoreLogs Logs = new StoreLogs()
            {
                Id = 1,
                DateTime = dateT,
                TaskName = task,
                SrcAddress = srcPath,
                DstAddress = path,
                FileSize = DirSize(new DirectoryInfo(path)),
                DelayTransfer = 10,
            };

            // Record JSON data in the variable
            string strResultJson = JsonConvert.SerializeObject(Logs);

            // Show the JSON Data
            Console.WriteLine(strResultJson);

            // Write JSON Data in another file
            File.WriteAllText(@"C:\Users\ASUS\Desktop\Backup\logs.json", strResultJson);

            // Verify if a Backup directory exist and create it if not
            Logs.CreateDir(path, srcPath);
            
            // Copy files from the source directory to the destination
            Copy(path, srcPath);

            Console.ReadLine();
        }
    }
}
