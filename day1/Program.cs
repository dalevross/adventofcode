using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {

            int sum = 0;
            int sumfuel = 0;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int mass = int.Parse(line);
                    sum += calculateFuel(mass);
                    sumfuel += calculatewithFuel(mass);
                }

            }
            Console.WriteLine(sum);
            Console.WriteLine(calculatewithFuel(14));
            Console.WriteLine(sumfuel);

        }

        private static int calculatewithFuel(int mass)
        {
            if (calculateFuel(mass) <= 0)
                return 0;
            else
            {
                int fuel = calculateFuel(mass);
                return fuel + calculatewithFuel(fuel);
            }
        }

        static int calculateFuel(int mass)
        {
            return (int)Math.Floor(mass / 3.0) - 2;
        }
    }
}
