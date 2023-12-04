// See https://aka.ms/new-console-template for more information
using Microsoft.Win32.SafeHandles;

Console.WriteLine(PartOne());

static double PartOne()
{
    string line;
    double totalPoints = 0;
    using(StreamReader sr = new StreamReader("input.txt"))
    {
        

        while((line = sr.ReadLine()) != null)
        {
            string[] segments = line.Split(new char[]{':','|'});
            int[] winningNumbers = segments[1].Trim().Split(' ').Where(s =>s.Trim() != "").Select(x => Int32.Parse(x)).ToArray();
            int[] numbersIhave = segments[2].Trim().Split(' ').Where(s =>s.Trim() != "").Select(x => Int32.Parse(x)).ToArray();
            var matches =  winningNumbers.Intersect(numbersIhave);
            int matchCount = matches.Distinct().Count();
            double currentPoints = matchCount == 0 ? 0 : Math.Pow(2,matchCount-1);
            totalPoints += currentPoints;


        }



    }
    return totalPoints;
}
