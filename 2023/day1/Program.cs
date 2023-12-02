// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.ComponentModel.Design;

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

    List<Tuple<string,int>> occurences = new List<Tuple<string, int>>();

    for(int i = 0; i < line.Length;i++)
    {
        if (numberMap.Where(number => line.Substring(i).StartsWith(number.Key)).Count() > 0)
        {
            var numberString = numberMap.Where(number => line.Substring(i).StartsWith(number.Key)).First().Key;
            occurences.Add(new Tuple<string, int>(numberString,i)); 
        }      
    }


    if(occurences.Count != 0 )
    {
        int numOccurencies = occurences.Count;

        for(int i = 0;i<numOccurencies;i++)
        {

           if(i>0)
           {    
               if(occurences[i].Item2 < occurences[i -1].Item2 
                + occurences[i-1].Item1.Length)
                {
                    line = line.Substring(0,occurences[i-1].Item2 + occurences[i -1].Item1.Length)
                    + line.Substring(occurences[i].Item2);

                    occurences = new List<Tuple<string, int>>();
                
                    for(int j = 0; j < line.Length;j++)
                    {
                        if (numberMap.Where(number => line.Substring(j).StartsWith(number.Key)).Count() > 0)
                        {
                            var numberString = numberMap.Where(number => line.Substring(j).StartsWith(number.Key)).First().Key;
                            occurences.Add(new Tuple<string, int>(numberString,j)); 
                        }      
                    }

                }

           }
           //line = line.Replace(occurencies.ElementAt(i).Key, numberMap[occurencies.ElementAt(i).Key].ToString());
        }

        //foreach(KeyValuePair<string,int> kvp in occurencies)
        //{
                line = line.Replace(occurences.First().Item1, numberMap[occurences.First().Item1].ToString());
                line = line.Replace(occurences.Last().Item1, numberMap[occurences.Last().Item1].ToString());
                
        //}
       
        
    }
    

    return line;    
}