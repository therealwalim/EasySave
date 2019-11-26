using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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


        public void Copy(string path, string srcPath)
        {
            var diSource = new DirectoryInfo(srcPath);
            var diTarget = new DirectoryInfo(path);

            CopyAll(diSource, diTarget);
        }

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
