using System;
using System.IO;
using Newtonsoft.Json;

namespace ProjetPrograSys
{
    class StoreLogs
    {
        public String Id { get; set; }
        public string DateTime { get; set; }
        public string TaskName { get; set; }
        public string SrcAddress { get; set; }
        public string DstAddress { get; set; }
        public double FileSize { get; set; }
        public double DelayTransfer { get; set; }
        // public string path { get; set; }


        public long DirSize(DirectoryInfo strPath)
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

        // Copy function
        public void Copy(string path, string srcPath)
        {
            var diSource = new DirectoryInfo(srcPath);
            var diTarget = new DirectoryInfo(path);

            CopyAll(diSource, diTarget);
        }

        // Function to Copy All Files
        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                // Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
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

        // Store JSON Objects
        public void StoreJSON(string strPath, string MyJSON, string strResultJson)
        {
            if (File.Exists(strPath))
            {
                FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.ReadWrite);
                fs.SetLength(fs.Length - 1);
                fs.Close();

                MyJSON = "," + strResultJson;
                File.AppendAllText(strPath, MyJSON + "]");
                Console.WriteLine("The file exists.");
            }
            else if (!File.Exists(strPath))
            {
                MyJSON = "[" + strResultJson + "]";
                File.WriteAllText(strPath, MyJSON);
                Console.WriteLine("The file doesn't exists.");
            }
            else
            {
                Console.WriteLine("Error");
            }

            // End
            Console.WriteLine("JSON Object generated !");
        }

        // Function to read JSON
        public void ReadJSON(string strPath)
        {
            dynamic l = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(strPath));

            foreach (var o in l)
            {
                Console.WriteLine(o);
            }
        }

        // Method to create the backup directory
        public void CreateDir(string path, string srcPath)
        {
            // Specify the directory you want to manipulate.
            /*string path = @"C:\Users\ASUS\Desktop\Backup\"*/;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

        }
    }
 }
