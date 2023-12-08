// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());

static int PartOne()
{
    int numSteps = 0;

    Dictionary<string,Tuple<string,string>> mappings = new Dictionary<string, Tuple<string, string>>();

    using(StreamReader sr = new StreamReader("input.txt"))
    {

        string? instructions = sr.ReadLine().Trim();
        sr.ReadLine();

        string? line;


        while((line = sr.ReadLine()) != null)
        {
            Match m = Regex.Match(line,@"(?<node>[A-Z]+) = \((?<left>[A-Z]+), (?<right>[A-Z]+)\)");
            string node = m.Groups["node"].Value;
            string left = m.Groups["left"].Value;
            string right = m.Groups["right"].Value;
            mappings.Add(node, new Tuple<string, string>(left,right));
        }

        string currentNode = "AAA";
        while( currentNode != "ZZZ")
        {
            foreach(char move in instructions)
            {

                currentNode = move == 'L' ?  mappings[currentNode].Item1 : mappings[currentNode].Item2;
                numSteps++;
            }
        }


    }

    return numSteps;
}


static long PartTwo()
{
    long numSteps = 0;

    Dictionary<string,Tuple<string,string>> mappings = new Dictionary<string, Tuple<string, string>>();

    string? instructions;
    using(StreamReader sr = new StreamReader("input.txt"))
    {

        instructions = sr.ReadLine().Trim();
        sr.ReadLine();

        string? line;


        while((line = sr.ReadLine()) != null)
        {
            Match m = Regex.Match(line,@"(?<node>\w+) = \((?<left>\w+), (?<right>\w+)\)");
            string node = m.Groups["node"].Value;
            string left = m.Groups["left"].Value;
            string right = m.Groups["right"].Value;
            mappings.Add(node, new Tuple<string, string>(left,right));
        }
    }

    List<string> currentNodes = mappings.Keys.Where(key => key.EndsWith('A')).ToList();
    List<long> stepsForEach = new List<long>();
    foreach(string node in currentNodes){
        string currentNode = node;
        numSteps = 0;
        while( !currentNode.EndsWith('Z'))
        {
            foreach(char move in instructions)
            {
                

                currentNode = move == 'L' ? mappings[currentNode].Item1
                : mappings[currentNode].Item2;
                numSteps++;
            }
        }
        stepsForEach.Add(numSteps);
    }
    

    return findlcm(stepsForEach);
}

static long findlcm(List<long> arr)
{
    // Initialize answer
    long ans = arr[0];
 
    for (int i = 1; i < arr.Count; i++)
        ans = (((arr[i] * ans)) /
                gcd(arr[i], ans));
 
    return ans;
}

static long gcd(long a, long b)
{
    if (b == 0)
        return a;
    return gcd(b, a % b);
}
 