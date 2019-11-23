using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjetPrograSys
{
    class StoreLogs
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public string TaskName { get; set; }
        public string SrcAddress { get; set; }
        public string DstAddress { get; set; }
        public double FileSize { get; set; }
        public double DelayTransfer { get; set; }
        public string path { get; set; }

        

        public void StoreData(string path, string srcPath)
        {
            // Specify the directory you want to manipulate.
            /*string path = @"C:\Users\ASUS\Desktop\Backup\"*/;

            DirectoryInfo diSource = new DirectoryInfo(path);
            DirectoryInfo diTarget = new DirectoryInfo(srcPath);

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

                //CopyFiles of the directory
                


            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

        }
    }
 }
