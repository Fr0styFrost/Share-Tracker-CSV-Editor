using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace STCSVeditor
{
    class Program
    {
        static void Main(string[] args)
        {
           
            DirectoryInfo d = new DirectoryInfo(@"Y:\Snet"); 
            FileInfo[] Files = d.GetFiles("*.csv"); //Getting csv files
            string FileName = "";
            foreach (FileInfo file in Files)
            {   FileName = file.Name;
                if (File.Exists(@"C:\temp\" + FileName)) //Checks if file exists skips file if it does and creats one if it doesnt.
                {
                    Console.WriteLine(FileName + " Exists");
                }
                

                
                else
                {
                    StreamWriter WriteF = new StreamWriter(@"C:\temp\" + FileName);
                    string[] lines = File.ReadAllLines(@"Y:\Snet\" + FileName);
                    foreach (string line in lines)
                    {
                        string[] words = line.Split(','); //splits csv file into seprate cells.
                        foreach (string word in words)
                        {
                            if (word != "" && word != " " && word != null) //if CSV cell is empty blank space or error then it replaces or inserts a 0.
                            {
                                WriteF.Write(word + ",");
                            }
                            else
                            {
                                WriteF.Write("0" + ",");
                            }

                        }
                        WriteF.Write(Environment.NewLine);
                    }
                    Console.WriteLine(FileName + " Complete"); //informs wich files have been completed.
                }                       
                
            }
            Console.WriteLine("Process is complete"); //informs you the process is complete and you may close the console.
            Console.ReadKey();
        } 
    }
}
