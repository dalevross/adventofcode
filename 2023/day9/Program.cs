// See https://aka.ms/new-console-template for more information
Console.WriteLine(PartOne());
Console.WriteLine(PartTwo());

static long PartOne()
{

    long sum = 0;

    using(StreamReader sr = new StreamReader("input.txt"))
    {
        string? line;
        while((line = sr.ReadLine()) != null)
        {
            List<List<long>> sequences = new List<List<long>>();
            List<long> nextSequence = line.Split(' ').Select(x => Int64.Parse(x)).ToList();
            sequences.Add(nextSequence);
            while(!nextSequence.All( x => x == 0))
            {
               nextSequence = nextSequence
               .Where( (el, index) => index > 0)
               .Select((newEl,index) => nextSequence[index + 1] - nextSequence[index]).ToList();
                sequences.Add(nextSequence);

            }
            for(int i = sequences.Count -1; i > 0; i--)
            {
                sequences[i-1].Add(sequences[i-1].Last() + sequences[i].Last());
            }

            sum += sequences[0].Last();



        }

        
      
    }
    return sum;
}


static long PartTwo()
{

    long sum = 0;

    using(StreamReader sr = new StreamReader("input.txt"))
    {
        string? line;
        while((line = sr.ReadLine()) != null)
        {
            List<List<long>> sequences = new List<List<long>>();
            List<long> nextSequence = line.Split(' ').Select(x => Int64.Parse(x)).ToList();
            sequences.Add(nextSequence);
            while(!nextSequence.All( x => x == 0))
            {
               nextSequence = nextSequence
               .Where( (el, index) => index > 0)
               .Select((newEl,index) => nextSequence[index + 1] - nextSequence[index]).ToList();
                sequences.Add(nextSequence);

            }
            for(int i = sequences.Count -1; i > 0; i--)
            {
                sequences[i-1].Insert(0,(sequences[i-1].First()  - sequences[i].First()));
            }

            sum += sequences[0].First();



        }

        
      
    }
    return sum;
}