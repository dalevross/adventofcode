using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;


namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader sr = new StreamReader("input.txt"))
            {


                char[,] grid = new char[6,25];
                
                string line = sr.ReadLine();
                
                List<string> layers = Split(line,25*6).ToList();
                String minlayer = layers.Where(x => x.Count(f => f == '0') == layers.Select( x => x.Count(f => f == '0')).Min()).First();
                Console.WriteLine(minlayer.Count(f => f == '1') * minlayer.Count(f => f == '2') );
                layers.Reverse();
                foreach(string layer in layers)
                {
                    char[] chars = layer.ToCharArray();
                    int charindex =0;

                    foreach(int i in Enumerable.Range(0,6))
                    {

                        foreach(int j in Enumerable.Range(0,25))
                        {
                            grid[i,j] = (chars[charindex]=='2')?grid[i,j]:chars[charindex];
                            charindex++;
                        }

                    }


                }

                 foreach(int i in Enumerable.Range(0,6))
                 {

                        foreach(int j in Enumerable.Range(0,25))
                        {
                            
                            char pixel = grid[i,j] == '1'? '*': ' ';
                            Console.Write(pixel);
                            if(j==24)
                                Console.WriteLine();
                            
                        }
                       

                }
            
            
            }

            



        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
