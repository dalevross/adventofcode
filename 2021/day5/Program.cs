using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[1000,1000];
            for(int i = 0;i < 1000 ;i++)
            {
                for(int j= 0;j<1000;j++)
                {
                    grid[i,j] = 0;
                }
            }
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                String line;
                while((line = sr.ReadLine())!=null)
                {
                    string[] points = line.Split("->");
                    string[] xy = points[0].Trim().Split(',');
                    int x = Int32.Parse(xy[0]);
                    int y = Int32.Parse(xy[1]);
                    string[] x1y1 = points[1].Trim().Split(',');
                    int x1 = Int32.Parse(x1y1[0]);
                    int y1 = Int32.Parse(x1y1[1]);
                    if(x == x1)
                    {
                        if(y1 > y)
                        {
                            for(int i = y;i<=y1;i++)
                            {
                                grid[i,x]++;
                            }
                        }
                        else{
                            
                            for(int i = y1;i<=y;i++)
                            {
                                grid[i,x]++;
                            }
                        }
                    }
                    if(y == y1)
                    {
                        if(x1 > x)
                        {
                            for(int i = x;i<=x1;i++)
                            {
                                grid[y,i]++;
                            }
                        }
                        else{
                            
                            
                            for(int i = x1;i<=x;i++)
                            {
                                grid[y,i]++;
                            }
                        }
                    }
                }
            }
            int count=0;
            for(int i = 0;i < 1000 ;i++)
            {
                for(int j= 0;j<1000;j++)
                {
                    if(grid[i,j] > 1)
                        count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
