using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int part1count = 0;
            int part2count = 0;
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                String line;
                while((line = sr.ReadLine())!=null)
                {
                    int letteroccurence = 0;
                    string[] parts = line.Split(new char[]{' '});
                    string range = parts[0];
                    char letter = parts[1][0];
                    string password = parts[2];
                    int lowerbound = int.Parse(range.Split(new char[]{'-'})[0]);
                    int upperbound = int.Parse(range.Split(new char[]{'-'})[1]);
                    int lettercount = password.Count(c => c == letter);
                    if(lettercount >= lowerbound && lettercount <= upperbound)
                        part1count++;

                    if(password[lowerbound-1] == letter)
                        letteroccurence++;
                    
                    if(password[upperbound-1] == letter)
                        letteroccurence++;

                    if(letteroccurence == 1)
                        part2count++;
                    

                }
            }
            Console.WriteLine("Part 1 Count {0}",part1count);
            Console.WriteLine("Part 2 Count {0}",part2count);
        }
    }
}
