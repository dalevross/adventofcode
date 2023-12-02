// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;
using System.Linq;

///Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());

static int PartOne()
{

    StreamReader sr = new StreamReader("input.txt");
    string? line = "";
    int sum = 0;
    while((line = sr.ReadLine()) != null )
    {
        int calibrationValue = GetCalibrationValue(line);
        sum += calibrationValue;
    }

    return sum;

}

static int GetCalibrationValue(string line)
{   
    int i = 0; 
    int firstDigit;
    int lastDigit;
    while(!Int32.TryParse(line[i].ToString(),out firstDigit))
    {
        i++;
    }
    i= line.Length-1;
    while(!Int32.TryParse(line[i].ToString(),out lastDigit))
    {
        i--;
    }

    return Int32.Parse($"{firstDigit}{lastDigit}");

}

static int PartTwo()
{

    StreamReader sr = new StreamReader("input.txt");
    string? line = "";
    int sum = 0;
    string correctLine;
    while((line = sr.ReadLine()) != null )
    {
        correctLine = ReplaceWords(line);
        int calibrationValue = GetCalibrationValue(correctLine);
        sum += calibrationValue;
    }

    return sum;

}

static string ReplaceWords(string line)
{
    Dictionary<string,int> numberMap = new Dictionary<string, int>
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    Dictionary<int,Tuple<string,int>> occurencies = new Dictionary<int, Tuple<string, int>>();
    occurencies = numberMap
    .Select( (number,index) => new KeyValuePair<int,Tuple<string,int>>(index,new Tuple<string, int>(number.Key,line.IndexOf(number.Key))))
    .Where(number => number.Value.Item2 != -1).OrderBy(x=> x.Value.Item2)
    .ToDictionary<int,Tuple<string,int>>();


    if(occurencies.Count != 0 )
    {
        int numOccurencies = occurencies.Count;

        for(int i = 0;i<numOccurencies;i++)
        {

           if(i>0)
           {
                if(occurencies.ElementAt(i).Value.Item2 < occurencies.ElementAt(i -1).Value.Item2 
                + occurencies.ElementAt(i -1).Value.Item1.Length)
                {
                    line = line.Substring(0,occurencies.ElementAt(i-1).Value.Item2 + occurencies.ElementAt(i -1).Value.Item1.Length)
                    + line.Substring(occurencies.ElementAt(i).Value.Item2);

                    occurencies = numberMap
                    .Select( (number,index) => new KeyValuePair<int,Tuple<string,int>>(index,new Tuple<string, int>(number.Key,line.IndexOf(number.Key))))
                    .Where(number => number.Value.Item2 != -1).OrderBy(x=> x.Value.Item2)
                    .ToDictionary<int,Tuple<string,int>>();

                }

           }
           //line = line.Replace(occurencies.ElementAt(i).Key, numberMap[occurencies.ElementAt(i).Key].ToString());
        }

        //foreach(KeyValuePair<string,int> kvp in occurencies)
        //{
                line = line.Replace(occurencies.First().Value.Item1, numberMap[occurencies.First().Value.Item1].ToString());
                line = line.Replace(occurencies.Last().Value.Item1, numberMap[occurencies.Last().Value.Item1].ToString());
                
        //}
       
        
    }
    

    return line;    
}