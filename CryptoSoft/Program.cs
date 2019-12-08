/*
 *#######################################################################################
  #                                                                                     #
  #                                 CryptoSoft                                          #
  #                                                                                     #
  #######################################################################################

 * Before using that code make sure that you give 4 arguments like the following example :
 * 
 * λ CryptoSoft.exe [0] [1] [2] [3]
 * 
 * [0] : "source"
 * [1] : source path
 * [2] : "Destination"
 * [3] : Destination path
 * 
*/

using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            var extension = ".txt";

            DataEncryption data = new DataEncryption();

            if (args[1].EndsWith(extension) && args[3].EndsWith(extension))
            {
                data.Encrypt(args);
            }
            else
            {
                Console.WriteLine("Wrong extension, please enter a file with the "+extension+" extension");
            }



            // Check the extension of the file
            //string data = "euheuhuehfuehfuehfuhfuehueh.txt";
            //string[] extensions = { ".txt", ".csv", ".json" };
            //foreach (string x in extensions)
            //{
            //    string result;

            //    if (data.Contains(x))
            //    {
            //        Console.WriteLine("Match to "+x);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Doesn't match to "+x);
            //        result = "false";
            //    }
            //}
        }
    }
}

