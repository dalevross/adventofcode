using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> horizontalPositions = new List<int>();
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                horizontalPositions = sr.ReadLine().Split(',').Select(x => Int32.Parse(x)).ToList();
                
            }
            int[] fuelCosts = Enumerable.Repeat(0,horizontalPositions.Count).ToArray();

            for(int i = 0;i < fuelCosts.Length;i++)
            {
                int fuelCost = 0;
                for(int j = 0;j < horizontalPositions.Count;j++)
                {
                    int dif = Math.Abs(horizontalPositions[j] - horizontalPositions[i]);
                    fuelCost += dif * (dif + 1) / 2;
                }
                fuelCosts[i] = fuelCost;
            }

            Console.WriteLine(fuelCosts.Min());
        }
    }
}
