using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace day10
{
    class Program
    {

        static List<Tuple<int,int>> asteroids = new List<Tuple<int,int>>();
        static void Main(string[] args)
        {
           
            string line;
            int row = 0;
            using (StreamReader sr = new StreamReader("sample.txt"))
            {


                while ((line = sr.ReadLine()) != null)
                {
                    foreach(int y in line
                        .Select((letter,index) => (letter,index))
                        .Where( x  => x.letter == '#')
                        .Select(x => x.index))
                    {
                        asteroids.Add(new Tuple<int,int>(row,y));
    
                    }
                    row++;
                    
              }

              Tuple<int,int> bestposition = asteroids.Where( x => GetCount(x)
                == asteroids.Max( x =>  {return GetCount(x);})
                ).First();


             var test =  asteroids.Select(x => (x,GetCount(x)));
             Console.Write(bestposition);
              
            
            }

        }

        static int GetCount(Tuple<int,int> asteroid)
        {
            int count = 0;
            var lAsteroids  = new List<Tuple<int,int>>(asteroids);
            lAsteroids.Remove(asteroid);
            foreach (var otherasteroid in lAsteroids)
            {
                if(CanSee(asteroid,otherasteroid))
                {
                    count++;


                }
            }
            return count;
            
        }

        static bool CanSee(Tuple<int,int> asteroid, Tuple<int,int> otherasteroid)
        {

            Tuple<int,int> gradient = Gradient(asteroid,asteroid);
            return !asteroids.Exists(x =>
              x != asteroid &&
              x != otherasteroid &&
              Gradient(x,asteroid) == Gradient(otherasteroid,x) &&
              Enumerable.Range(
                    Math.Min(asteroid.Item1,otherasteroid.Item1),
                    Math.Abs(asteroid.Item1- otherasteroid.Item1)
              ).Contains(x.Item1));
            
        }
        static Tuple<int,int> Gradient(Tuple<int,int> p1, Tuple<int,int> p2)
        {
            return new Tuple<int,int>(p2.Item2 - p1.Item2,p2.Item1 -p1.Item1);
        }
    }
}
