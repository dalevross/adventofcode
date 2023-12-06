// See https://aka.ms/new-console-template for more information
//Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());

static int PartOne()
{

    string line;
    List<int> waysToWin = new List<int>();
    using(StreamReader sr = new StreamReader("input.txt"))
    {
        
        int[] times = sr.ReadLine().Split(':')[1].Split(' ').Where(x => x.Trim() != "").Select(x => Int32.Parse(x)).ToArray();
        int[] distances = sr.ReadLine().Split(':')[1].Split(' ').Where(x => x.Trim() != "").Select(x => Int32.Parse(x)).ToArray();
        for(int i = 0; i< times.Length;i++)
        {
            int numWaysToWin = 0;
            for(int j = 1; j < times[i];j++)
            {
                if((times[i] - j) * j > distances[i])
                    numWaysToWin++;

            }
            waysToWin.Add(numWaysToWin);
        }
    }
    return waysToWin.Aggregate((x, y) => x * y);;
}

static long PartTwo()
{

    string line;
    List<int> waysToWin = new List<int>();
    long numWaysToWin = 0;
    using(StreamReader sr = new StreamReader("input.txt"))
    {
        
        int[] times = sr.ReadLine().Split(':')[1].Split(' ').Where(x => x.Trim() != "").Select(x => Int32.Parse(x)).ToArray();
        int[] distances = sr.ReadLine().Split(':')[1].Split(' ').Where(x => x.Trim() != "").Select(x => Int32.Parse(x)).ToArray();

       long time = Int64.Parse(String.Join("",times));
       long distance = Int64.Parse(String.Join("",distances));

        for(long j = 1; j < time;j++)
        {
            if((time - j) * j > distance)
                numWaysToWin++;

        }
       
      
    }
    return numWaysToWin;
}
