// See https://aka.ms/new-console-template for more information
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Text.Unicode;

//Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());
static long PartOne()
{
    string? line;
    List<long> locations = new List<long>();

    using(StreamReader sr = new StreamReader("input.txt"))
    {

        line = sr.ReadLine();

        List<long> seeds = line.Split(':')[1].Split(' ').Where(x => x.Trim() != "").Select(x => Int64.Parse(x)).ToList();

        List<List<Tuple<long,long,long>>> almanac = new List<List<Tuple<long, long, long>>>();
        
        int mapNumber = 0;
            
        while((line = sr.ReadLine())!= null)
        {
            if(line.Trim() == "")
                continue;

            if(line.Contains(':'))
            {
                almanac.Add(new List<Tuple<long, long, long>>());
                mapNumber++;
                continue;
            }

            long[] ranges = line.Split(' ').Select(x => Int64.Parse(x)).ToArray();
            almanac[mapNumber-1].Add(new Tuple<long, long, long>(ranges[0],ranges[1],ranges[2]));                   
              
        }

        long currentValue = 0;
        foreach(long seed in seeds)
        {
            currentValue = seed;
            foreach(var section in almanac)
            {
                foreach(var mapping in section)
                {
                    long source = mapping.Item2;
                    long destination = mapping.Item1;
                    long range = mapping.Item3;
                    if(currentValue >= source && currentValue <= source + range - 1)
                    {
                        currentValue = destination - source + currentValue ;
                        break;
                    }
                    
                }


            }

            locations.Add(currentValue);
        }

    }






    return locations.Min();
    
}



static long PartTwo()
{
    string? line;
    List<long> locations = new List<long>();

    using(StreamReader sr = new StreamReader("input.txt"))
    {

        line = sr.ReadLine();

        List<long> seedRanges = line.Split(':')[1].Split(' ').Where(x => x.Trim() != "").Select(x => Int64.Parse(x)).ToList();

        List<long> seeds = new List<long>();
        for(int i=0;i < seedRanges.Count;i+=2)
        {
            long begin = seedRanges[i];
            long range = seedRanges[i+1];
            for(long j = begin;j < begin+range;j++)
            {
                seeds.Add(j);
            }
        }
        List<List<Tuple<long,long,long>>> almanac = new List<List<Tuple<long, long, long>>>();
        
        int mapNumber = 0;
            
        while((line = sr.ReadLine())!= null)
        {
            if(line.Trim() == "")
                continue;

            if(line.Contains(':'))
            {
                almanac.Add(new List<Tuple<long, long, long>>());
                mapNumber++;
                continue;
            }

            long[] ranges = line.Split(' ').Select(x => Int64.Parse(x)).ToArray();
            almanac[mapNumber-1].Add(new Tuple<long, long, long>(ranges[0],ranges[1],ranges[2]));                   
              
        }

        long currentValue = 0;
        foreach(long seed in seeds)
        {
            currentValue = seed;
            foreach(var section in almanac)
            {
                foreach(var mapping in section)
                {
                    long source = mapping.Item2;
                    long destination = mapping.Item1;
                    long range = mapping.Item3;
                    if(currentValue >= source && currentValue <= source + range - 1)
                    {
                        currentValue = destination - source + currentValue ;
                        break;
                    }
                    
                }


            }

            locations.Add(currentValue);
        }

    }






    return locations.Min();
    
}
