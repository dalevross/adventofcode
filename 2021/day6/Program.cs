using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                int numberofGenerations = 80;
                List<int> laternFishes = sr.ReadLine().Split(',').Select(x => Int32.Parse(x)).ToList();
                for(int i = 0;i<numberofGenerations;i++)
                {
                    int numberOfZeroes = laternFishes.Count(x=>x==0);
                    
                    laternFishes.AddRange(Enumerable.Repeat(9,numberOfZeroes));
                    laternFishes = laternFishes.Select((x,i) =>  (x == 0)? 6 : x -1).ToList();
                }
                Console.WriteLine(laternFishes.Count);
            }
           
        }
    }
}
