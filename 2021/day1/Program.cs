using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                int lastLine = Int32.Parse(sr.ReadLine());
                string nextLineStr;

                while((nextLineStr = sr.ReadLine())!=null)
                {
                    int nextLine = Int32.Parse(nextLineStr);
                    if(nextLine > lastLine)
                    {
                        count++;
                    }
                    lastLine = nextLine;
                

                }
            }
            Console.WriteLine("Increases {0}",count);
            count = 0;
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                string lines = sr.ReadToEnd();
                List<int> depths = lines.Split('\n').Select(x => Int32.Parse(x)).ToList<int>();
                List<int> windowedDepths = new List<int>();
                for(int i = 2;i<depths.Count;i++)
                {
                    int sum = depths[i] + depths[i-1] + depths[i-2];
                    windowedDepths.Add(sum);
                }

                for(int i = 1;i<windowedDepths.Count;i++)
                {
                    if(windowedDepths[i] > windowedDepths[i-1])
                     count++;
                }


            }

            Console.WriteLine("Increases {0}",count);
            
        }
    }
}
