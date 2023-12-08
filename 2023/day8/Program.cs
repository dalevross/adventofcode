// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine(PartOne());


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