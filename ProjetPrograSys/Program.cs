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
        static void Main(string[] args)
        {
            int test = 200;
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
            //File.WriteAllText(@"C:\Users\ASUS\Desktop\Backup\.json", strResultJson);

            //Logs.StoreData(path, srcPath);
            Console.ReadLine();
        }
    }
}
