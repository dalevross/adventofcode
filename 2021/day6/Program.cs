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
                int numberofGenerations = 256;
                List<int> laternFishAges = sr.ReadLine().Split(',').Select(x => Int32.Parse(x)).ToList();
                long[] state = Enumerable.Repeat(0L,9).ToArray();
                foreach (var laternFishAge in laternFishAges)
                {
                    state[laternFishAge]++;
                }
                for(int i = 0;i<numberofGenerations;i++)
                {
                    long state0 = state[0];

                    for(int j = 0;j< 8;j++)
                    {
                        state[j] = state[j+1];
                    }
                    state[6] += state0;
                    state[8] = state0;
                }
                Console.WriteLine(state.Sum());
            }
           
        }
    }
}
