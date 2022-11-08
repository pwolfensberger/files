using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;

namespace files_folders
{
    internal class Program
    {

        static void  Createfile(string myFile) {

            try
            {

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                docPath = Path.Combine(docPath, "cfiles\\", myFile);
                
                

                if (File.Exists(docPath)) {
                    Console.WriteLine("already is al file of that name there");
                    StreamWriter File1 = File.AppendText(docPath);
                    File1.WriteLine("hey");
                    File1.Close();
                }

                else
                {
                    StreamWriter file1 = File.CreateText(docPath);
                    file1.WriteLine("this is", myFile);
                    file1.Close();
                }

            }
            catch (IOException )
            { Console.Write("error writing to directroy");

            }
            
        }
        static void Taskone(string file1)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath = Path.Combine(docPath, "cfiles\\", file1);

            StreamWriter f = File.AppendText(docPath);
            string x = "yh";

            while (x != "") { 
            Console.WriteLine("eneter sentance");
            x = Console.ReadLine();
            f.WriteLine(x);

            }
            f.Close();
            

         }

        static void Tasktwo() {
            Console.WriteLine("eneter file name"); 
            string y = Console.ReadLine();
            Createfile(y);

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath = Path.Combine(docPath, "cfiles\\", y);

            StreamWriter f = File.AppendText(docPath);
            Random rnd = new Random();

            Console.WriteLine("how2 many random numbers");
            int x = Convert.ToInt16(Console.ReadLine());
         

            int[] nums = new int[x];
            for (int i = 0; i < x; i++) {
                nums[i] = rnd.Next(1, 100);
                string e = Convert.ToString(nums[i]);
                f.Write(e);
                f.Write(",");

            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int t = nums[j];
                        int r = nums[j + 1];
                        nums[j] = r;
                        nums[j + 1] = t;

                    }
                }
            }
            Console.WriteLine("eneter file name");
            string l = Console.ReadLine();
            Createfile(l);

            string docPath1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            docPath1 = Path.Combine(docPath1, "cfiles\\", l);
            StreamWriter n = File.AppendText(docPath1);
            for (int i = 0; i < x; i++)
            {
                n.WriteLine(nums[i]);
                Console.WriteLine(nums[i]);
            }
            n.Close();
            f.Close();


        }

        static void TaskThree(string word)
        {
            char[] wordchars = new char[word.Length];
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamReader myInFile = File.OpenText(Path.Combine(docPath, "cfiles\\stations.txt"));
            List<string> Cor = new List<string>();
            int CorrectsCount = 0;
            String line;
            while (!myInFile.EndOfStream)
            {
                line = myInFile.ReadLine();
                string[] stationsplit = line.Split(',');
                string station = stationsplit[0];
                station = station.ToLower();
                char[] chars = new char[line.Length];
                bool included = false;
                for (int x = 0; x < station.Length; x++)
                {

                    for (int o = 0; o < word.Length; o++)
                    {
                        for (int u = 0; u < station.Length; u++)
                        {

                            if (station[u] == word[o])
                            {
                                included = true;
                            }
                        }
                    }


                }
                if (included == false)
                {
                    Cor.Add(station);
                    CorrectsCount += 1;
                }

            }
            for (int z = 0; z < CorrectsCount; z++)
            {
                Console.WriteLine("{1} station contains no letters from the word \"{0}\"", word, Cor[z]);
            }

        }


        static void Main()
        {
            //Createfile("sentences.txt");
            //Taskone("sentences.txt");
            //Tasktwo();
            TaskThree("mackerel");
        }
    }
}
