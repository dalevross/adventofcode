using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int treecount = 0;
            long product = 1;
            List<List<char>> grid = new List<List<char>>();
           
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                List<Tuple<int,int>> slopes = new List<Tuple<int,int>>();
                slopes.Add(new Tuple<int, int>(1,1));
                slopes.Add(new Tuple<int, int>(3,1));
                slopes.Add(new Tuple<int, int>(5,1));
                slopes.Add(new Tuple<int, int>(7,1));
                slopes.Add(new Tuple<int, int>(1,2));

                List<int> products = new List<int>();
                
                String line;
                while((line = sr.ReadLine())!=null)
                {
                   List<char> row = line.ToCharArray().ToList();
                   grid.Add(row);                   

                }
                
                int width = grid[0].Count;
                foreach (var slope in slopes)
                {
                    int x = 0;
                    int y = 0;
                    int treecount = 0;
                    while(y+slope.Item2<grid.Count)
                    {
                        x = ( x +slope.Item1) % width;
                        y = y + slope.Item2;
                        if(grid[y][x]=='#')
                            treecount++;
                        
                    }
                   product = treecount * product;
                    
                }

                
            }
            Console.WriteLine("Part 1 Count {0}",product);
        }
    }
}
