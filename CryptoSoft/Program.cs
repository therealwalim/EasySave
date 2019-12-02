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
 * [0] : "Source"
 * [1] : Source path
 * [2] : "Destination"
 * [3] : Destination path
 * 
*/

using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CryptoSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            DataEncryption data = new DataEncryption();
            data.Encrypt(args);
        }
    }
}

