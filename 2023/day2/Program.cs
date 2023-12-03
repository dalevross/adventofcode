// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());

static int PartOne(){
    int sum = 0;
    string? line;
    Dictionary<string,int> totals = new Dictionary<string, int>{
        {"red",12},
        {"green",13},
        {"blue",14}

    };
    using(StreamReader sr = new StreamReader("input.txt"))
    {
        while((line = sr.ReadLine()) != null)
        {
           string[] segments = line.Split(new char[]{',',';',':'});
           int gameNum = Int32.Parse(segments[0].Split(' ')[1].Trim());
           bool gameIsPossible = true;
           for(int i = 1;i < segments.Length;i++)
           { 
               string[] cubes = segments[i].Trim().Split(' ');
               int count = Int32.Parse(cubes[0]);
               string color = cubes[1].Trim();
               if(totals[color] < count)
               {
                    gameIsPossible = false;
                    break;
               }
           }
           sum += gameIsPossible ? gameNum : 0;

        }
    }

    return  sum;
}

static int PartTwo(){
    string? line;
   
    int sum = 0;
    using(StreamReader sr = new StreamReader("input.txt"))
    {
        while((line = sr.ReadLine()) != null)
        {
            Dictionary<string,int> maxCubes = new Dictionary<string, int>{
            {"red",0},
            {"green",0},
            {"blue",0}

         };
           string[] segments = line.Split(new char[]{',',';',':'});
           
           for(int i = 1;i < segments.Length;i++)
           { 
               string[] cubes = segments[i].Trim().Split(' ');
               int count = Int32.Parse(cubes[0]);
               string color = cubes[1].Trim();
               maxCubes[color] = (count > maxCubes[color]) ? count : maxCubes[color];
           }
           int power = maxCubes["red"] * maxCubes["green"] * maxCubes["blue"];
           sum += power;
           

        }
    }

    return  sum;
}

