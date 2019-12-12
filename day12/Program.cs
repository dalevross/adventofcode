using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace day12
{
    class Program
    {

        static List<Tuple<int, int, int>> semifinalmoons = new List<Tuple<int, int, int>>();
        static Dictionary<Tuple<int, int, int>, Tuple<int, int, int>> finalvelocity = new Dictionary<Tuple<int, int, int>, Tuple<int, int, int>>();
        static void Main(string[] args)
        {


            List<Tuple<int, int, int,char>> moons = new List<Tuple<int, int, int>>();
            /*moons.Add(new Tuple<int, int, int>(-6, 2, -9));
            moons.Add(new Tuple<int, int, int>(12, -14, -4));
            moons.Add(new Tuple<int, int, int>(9, 5, -6));
            moons.Add(new Tuple<int, int, int>(-1, -4, 9));
            */
            moons.Add(new Tuple<int, int, int,char>(-1, 0, 2,'I'));
            moons.Add(new Tuple<int, int, int,char>(2, -10, -7,'E'));
            moons.Add(new Tuple<int, int, int,char>(4, -8, 8,'G'));
            moons.Add(new Tuple<int, int, int,char>(3, 5, -1,'C'));


            Console.WriteLine(CalculateEnergy(moons, 2772));



        }

        static int CalculateEnergy(List<Tuple<int, int, int,char>> moons, int runs)
        {
            //Dictionary<Tuple<Tuple<int,int,int>,Tuple<int,int,int>>,Tuple<int,int,int>> velocities = new Dictionary<Tuple<Tuple<int, int, int>, Tuple<int, int, int>>, Tuple<int, int, int>>();
            Dictionary<Tuple<int, int, int>, Tuple<int, int, int>> velocities = new Dictionary<Tuple<int, int, int>, Tuple<int, int, int>>();

            var total = 0;
            var run = 0;
            Console.WriteLine($"After {run} runs");
            foreach (var moon in moons)
            {

                velocities.Add(moon, new Tuple<int, int, int>(0, 0, 0));
                Console.WriteLine($"pos: {moon} , velocity {velocities[moon]}");

            }

            while (run < runs)
            {



                foreach (var moon in moons)
                {
                    var othermoons = moons.Where(m => m != moon);
                    foreach (var othermoon in othermoons)
                    {
                        var v = velocities[moon];
                        velocities[moon] = new Tuple<int, int, int>(v.Item1 + Math.Sign(othermoon.Item1 - moon.Item1)
                        , v.Item2 + Math.Sign(othermoon.Item2 - moon.Item2), v.Item3 + Math.Sign(othermoon.Item3 - moon.Item3));
                    }

                }
                if (run == runs - 1)
                {
                    finalvelocity = new Dictionary<Tuple<int, int, int>, Tuple<int, int, int>>(velocities);
                    semifinalmoons = new List<Tuple<int, int, int>>(moons);
                }
                for (int i = 0; i < moons.Count(); i++)
                {
                    var tempMoon = new Tuple<int, int, int>(moons[i].Item1, moons[i].Item2, moons[i].Item3);
                    moons[i] = new Tuple<int, int, int>(
                        moons[i].Item1 + velocities[moons[i]].Item1,
                        moons[i].Item2 + velocities[moons[i]].Item2,
                        moons[i].Item3 + velocities[moons[i]].Item3
                    );
                    var tempVelocity = velocities[tempMoon];
                    velocities.Remove(tempMoon);
                    velocities.Add(moons[i], tempVelocity);


                }

                run++;
                if (true)//run > 1385 && run <= 1387)
                {
                    Console.WriteLine($"After {run} runs");
                    foreach (var moon in moons)
                    {
                        Console.WriteLine($"pos: {moon} , velocity {velocities[moon]}");
                    }
                    Console.WriteLine();
                }


            }

            var kinetic = 0;
            var potential = 0;
            Console.WriteLine($"After {run} runs");
            foreach (var moon in moons)
            {

                potential = Math.Abs(moon.Item1) + Math.Abs(moon.Item2) + Math.Abs(moon.Item3);
                //var oldmoon = semifinalmoons[moons.IndexOf(moon)];
                var velocity = velocities[moon];
                kinetic = Math.Abs(velocity.Item1) + Math.Abs(velocity.Item2) + Math.Abs(velocity.Item3);
                total += potential * kinetic;
                Console.WriteLine($"moon {moon } potential {potential} velocity {velocity} kinetic {kinetic} ");
            }
            return total;

        }
    }
}
