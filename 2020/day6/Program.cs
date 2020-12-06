using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                string allLines;
                allLines = sr.ReadToEnd();
                List<string> groups = allLines.Split("\r\n\r\n").Select(s => s.Replace("\r\n","")).ToList();
                List<int> counts = groups.Select(s => s.Distinct().Count()).ToList(); 
                int sum = counts.Sum();

                Console.WriteLine("Sum {0}",sum);
                List<string[]> groups2 = allLines.Split("\r\n\r\n").Select(s => s.Split("\r\n")).ToList();
                List<int> counts2 = new List<int>();
                
                foreach (var sa in groups2)
                {
                    int count = 0;
                    foreach (var str in sa)
                    {
                        count = 0;
                        foreach (var c in str)
                        {
                            if(sa.All(s => s.Contains(c)))
                            {
                                count++;
                                
                            }
                        }
                        
                        
                    }
                    counts2.Add(count);
                    
                }
                int sum2 = counts2.Sum();

                Console.WriteLine("Sum {0}",sum2);
            }           
        }
    }
}
