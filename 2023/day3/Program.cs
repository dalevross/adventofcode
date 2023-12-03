// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());


int PartOne()
{
    int sum = 0;
    string? line;
    Dictionary<Tuple<int,int>,string> partnums = new Dictionary<Tuple<int, int>, string>();
    using(StreamReader sr = new StreamReader("input.txt"))
    {
        int lineNum = 0;
        char[,] grid = new char[140,140];
        while((line = sr.ReadLine()) != null)
        {  
             bool numStarted = false;
             int startIndex = 0;
             StringBuilder sb = new StringBuilder();
            for(int i =0;i < line.Length;i++) 
            {
                if(char.IsDigit(line[i]))
                {
                    if(!numStarted)
                    {
                        sb = new StringBuilder();
                        numStarted = true;
                        startIndex = i;
                    }
                    sb.Append(line[i]);
                    
                }
                else
                {
                    if(numStarted)
                    {
                        partnums.Add(new Tuple<int, int>(lineNum,startIndex),sb.ToString());
                        numStarted = false;
                    }

                }
               
                grid[lineNum,i] = line[i];
            }
            if(numStarted)
            {
                partnums.Add(new Tuple<int, int>(lineNum,startIndex),sb.ToString());
                numStarted = false;

            }
            lineNum++;
        
        }
        foreach(KeyValuePair<Tuple<int,int>,string> kvp in partnums)
        {
            bool isPartNum = false;
            int row = kvp.Key.Item1;
            int column = kvp.Key.Item2;
            for(int i = row -1;i <= row + 1;i++)
            {
                for(int j = column -1; j<= column + kvp.Value.Length;j++)
                {
                    if(i >= 0 && i < 140 && j >= 0 && j < 140)
                    {
                        if(!Char.IsDigit(grid[i,j]) && !(grid[i,j] == '.'))
                        {
                            isPartNum = true;
                            Console.WriteLine($"({i},{j} {kvp.Value})");
                            break;
                        }
                                               
                    }
                   
                }
                if(isPartNum)
                    break;
            }
            sum += (isPartNum) ? Int32.Parse(kvp.Value) : 0;
            
        }
    }
    return sum;
}


int PartTwo()
{
    return 0;
}