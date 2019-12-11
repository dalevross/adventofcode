using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace day10
{
    class Program
    {

        static List<Tuple<int, int>> asteroids = new List<Tuple<int, int>>();
        static Dictionary<Tuple<Tuple<int, int>, Tuple<int, int>>,bool> cansee = new Dictionary<Tuple<Tuple<int, int>, Tuple<int, int>>, bool>();
        static Dictionary<Tuple<int, int>, List<Tuple<Tuple<int, int>, Tuple<int, int>>>> blocklists = new Dictionary<Tuple<int, int>, List<Tuple<Tuple<int, int>, Tuple<int, int>>>>();
        static void Main(string[] args)
        {

            string line;
            int row = 0;
            using (StreamReader sr = new StreamReader("input.txt"))
            {


                while ((line = sr.ReadLine()) != null)
                {
                    foreach (int y in line
                        .Select((letter, index) => (letter, index))
                        .Where(x => x.letter == '#')
                        .Select(x => x.index))
                    {
                        var asteroid = new Tuple<int, int>(y, row);
                        asteroids.Add(asteroid);
                        blocklists.Add(asteroid, new List<Tuple<Tuple<int, int>, Tuple<int, int>>>());
                        
                    }
                    row++;

                }


                //Dictionary<Tuple<int,int>,int> countDict = new Dictionary<Tuple<int, int>, int>();
                var counts = asteroids.Select(x => (x, GetCount(x)))
                .ToDictionary(x => x.Item1,x =>x.Item2);
                
               
                var bestposition = asteroids.Where( (asteroid) => counts[asteroid]
                == counts.Max((x)  =>  {return x.Value;})
                ).Select( asteroid => (asteroid, counts.Max((x)  =>  {return x.Value;} ))).First();

               
               Console.Write($"{bestposition}");


            }

        }

        static int GetCount(Tuple<int, int> asteroid)
        {
            int count = 0;
            var lAsteroids = new List<Tuple<int, int>>(asteroids);
            lAsteroids.Remove(asteroid);
            foreach (var otherasteroid in lAsteroids)
            {
                if (CanSee(asteroid, otherasteroid))
                {
                    count++;
                    
                    //Console.WriteLine($"{asteroid} can see {otherasteroid} via gradient {Gradient(asteroid, otherasteroid)}");


                }
                else
                {
                    //Console.WriteLine($"{asteroid} can't see {otherasteroid} via gradient {Gradient(asteroid, otherasteroid)}");
                }
            }
            return count;

        }

        static bool CanSee(Tuple<int, int> asteroid, Tuple<int, int> otherasteroid)
        {

            Tuple<int, int> gradient = Gradient(asteroid, otherasteroid);
            
            if(cansee.ContainsKey(new Tuple<Tuple<int, int>, Tuple<int, int>>(asteroid,otherasteroid)))
            {
                return cansee[new Tuple<Tuple<int, int>, Tuple<int, int>>(asteroid,otherasteroid)];
            }
            /*Check if vertical*/
            if (asteroid.Item1 == otherasteroid.Item1)
            {

                var blockers = asteroids.Where(x => !x.Equals(asteroid) &&
                !x.Equals(otherasteroid)
                 && x.Item1 == asteroid.Item1
                 && Enumerable.Range(
                 Math.Min(asteroid.Item2, otherasteroid.Item2),
                 Math.Abs(asteroid.Item2 - otherasteroid.Item2)).Contains(x.Item2));
                if (blockers.Count() > 0)
                {
                    blocklists[asteroid].Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(otherasteroid, blockers.First()));
                    cansee[new Tuple<Tuple<int, int>, Tuple<int, int>>(otherasteroid,asteroid)] = false;
                    return false;
                }
            }
            /*Check if horizontal*/
            else if (asteroid.Item2 == otherasteroid.Item2)
            {

                var blockers = asteroids.Where(x => !x.Equals(asteroid) &&
                !x.Equals(otherasteroid)
                 && x.Item2 == asteroid.Item2
                 && Enumerable.Range(
                 Math.Min(asteroid.Item1, otherasteroid.Item1),
                 Math.Abs(asteroid.Item1 - otherasteroid.Item1)).Contains(x.Item1));
                if (blockers.Count() > 0)
                {
                    blocklists[asteroid].Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(otherasteroid, blockers.First()));
                    cansee[new Tuple<Tuple<int, int>, Tuple<int, int>>(otherasteroid,asteroid)] = false;
                    return false;
                }

            }
            else
            {

                var blockers = asteroids.Where(x =>
                    !x.Equals(asteroid) &&
                  !x.Equals(otherasteroid) &&
                    Gradient(x, asteroid).Equals(Gradient(otherasteroid, x)) &&
                  Enumerable.Range(
                     Math.Min(asteroid.Item1, otherasteroid.Item1),
                     Math.Abs(asteroid.Item1 - otherasteroid.Item1)).Contains(x.Item1));



                if (blockers.Count() > 0){
                    blocklists[asteroid].Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(otherasteroid, blockers.First()));
                    cansee[new Tuple<Tuple<int, int>, Tuple<int, int>>(otherasteroid,asteroid)] = false;
                    return false;
                }
            }
            cansee[new Tuple<Tuple<int, int>, Tuple<int, int>>(otherasteroid,asteroid)] = true;
            return true;

        }
        static Tuple<int, int> Gradient(Tuple<int, int> p1, Tuple<int, int> p2)
        {
            var gradient = new Tuple<int, int>(p2.Item2 - p1.Item2, p2.Item1 - p1.Item1);
            
            if (gradient.Item2 != 0 && gradient.Item1 != 0)
                gradient = new Tuple<int, int>(gradient.Item1 / GCD(gradient.Item1, gradient.Item2),
                                          gradient.Item2 / GCD(gradient.Item1, gradient.Item2));
            
            return gradient;
        }

        static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int r;

            // loop till remainder is 0
            while (b > 0)
            {
                // calculate remainder
                r = a % b;

                // a becomes b and b becomes r
                a = b;
                b = r;
            }

            return a;
        }
    }
}
