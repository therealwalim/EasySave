using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CryptoSoft
{
    class DataEncryption
    {
        private static int key = 10110111; // The key used to "encrypt"

        private static string sourcePath;
        private static string destinationPath;

        private static string mode = "encrypt";

        public void Encrypt(string[] args)
        {
            if (verifyArgs(args)) // If Arguments are valid
            {
                sourcePath = args[1];
                destinationPath = args[3];
                try
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    Encrypt(sourcePath, destinationPath, mode, key);
                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms.");
                    Console.WriteLine("");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadLine();
                }

            }
        }
        // Check if all arguments passed to the CryptoSoft.exe are valid
        public bool verifyArgs(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments passed to CryptoSoft!");
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
                return false;
            }
            else
            {
                if (args.Length != 4)
                {
                    Console.WriteLine("Not enough arguments: passed " + args.Length + " instead of 4 arguments.");
                    Console.WriteLine("Arguments provided:");
                    for (int i = 0; i <= args.Length; i++)
                    {
                        Console.WriteLine("[" + i + "] " + args[i]);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    if (args[0] == "source") // If first argument is "source", then we check the third argument
                    {
                        if (args[2] == "destination") // if third argument is "destination", then we check if the source file exists
                        {
                            if (File.Exists(args[1])) // If the source file exists, then we check the destination directory
                            {
                                if (Directory.Exists(Path.GetDirectoryName(args[3]))) // If the destination directory exists
                                {
                                    return true;
                                }
                                else
                                {
                                    Console.WriteLine("Destination Folder does not exist.");
                                    Console.ReadLine();
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Source file does not exist.");
                                Console.ReadLine();
                                return false;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Keywork 'destination' not at position 2 of the Array of arguments. Current [2]: " + args[2]);
                            Console.ReadLine();
                            return false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Keywork 'source' not at position 0 of the Array of arguments. Current [0]: " + args[0]);
                        Console.ReadLine();
                        return false;
                    }
                }
            }
        }

        // Encrypt using XOR
        public void Encrypt(string sourcePath, string destinationPath, string mode, int key)
        {
            ArrayList inputArray = new ArrayList();
            ArrayList outputArray = new ArrayList();

            using (FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        inputArray.Add(sr.ReadLine());
                    }
                    sr.Close();
                }
                fs.Close();
                fs.Dispose();

            }

            foreach (string inputLine in inputArray)
            {
                outputArray.Add(XORProvider(inputLine, key));
            }

            TextWriter tw = new StreamWriter(destinationPath);

            foreach (string encoded in outputArray)
            {
                tw.WriteLine(encoded);
            }

            tw.Close();
        }

        public string XORProvider(string inputText, int key)
        {
            StringBuilder inSb = new StringBuilder(inputText);
            StringBuilder outSb = new StringBuilder(inputText.Length);
            char c;
            for (int i = 0; i < inputText.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key);
                outSb.Append(c);
            }
            return outSb.ToString();
        }
    }
}
