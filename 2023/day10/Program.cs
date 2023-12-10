// See https://aka.ms/new-console-template for more information
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine(PartTwo());

static long PartOne()
{

    string? line;
    List<List<char>> maze = new List<List<char>>();
    int height = 0;
    int width = 0;
    Tuple<int,int> start = new Tuple<int, int>(0,0);
    bool foundStart = false;
    int steps;

    using(StreamReader sr = new StreamReader("input.txt"))
    {

        
        while((line = sr.ReadLine()) !=null)
        {
            List<char> row = line.ToCharArray().ToList();
            if(!foundStart)
            {
                if(line.IndexOf('S') != -1)
                {
                    start = new Tuple<int,int>(height,line.IndexOf('S'));
                    foundStart = true;
                }
            }
            maze.Add(row);
            height++;
        }

        width = maze[0].Count;

        //Console.WriteLine(new Tuple<int,int>(width,height));

        
        
    }

    HashSet<Tuple<int,int>> visited = new HashSet<Tuple<int, int>>();
    visited.Add(start);

    Tuple<int,int> currentPosition = start;
    //Console.WriteLine(start);
    bool foundNext = false;
    char direction = '*';

    List<Tuple<int,int>> validOffset = new List<Tuple<int, int>>{
        
        new Tuple<int, int>(1,0),
        new Tuple<int, int>(0,1),
        new Tuple<int, int>(0,-1),
        new Tuple<int, int>(-1,0),
        
        


    };
   foreach(var offset in validOffset){
        int i = currentPosition.Item1 + offset.Item1;
        int j = currentPosition.Item2 + offset.Item2;

        if( i < 0 || i > height -1 || j < 0 || j > width - 1) 
            continue;
        if(!".S".Contains(maze[i][j]))
        {
            currentPosition = new Tuple<int, int>(i,j);
            switch(maze[currentPosition.Item1][currentPosition.Item2])
            {
                case '|':
                    direction = (currentPosition.Item1 < start.Item1) ? 'N' : 'S';
                    break;
                case '-':
                    direction = (currentPosition.Item2 < start.Item2) ? 'W' : 'E';
                    break;
                case 'L':
                    direction  = (currentPosition.Item1 < start.Item1) ? 'N' : 'E';
                    break;
                case 'J':
                    direction = (currentPosition.Item2 > start.Item2) ? 'N' : 'W';
                    break;
                case '7':
                    direction = (currentPosition.Item1 > start.Item1) ? 'S' : 'W';
                    break;
                case 'F':
                    direction = (currentPosition.Item1 > start.Item1) ? 'S' : 'E';
                    break;


            }

            foundNext = true;
            break;
        }
       
        if(foundNext)
            break;
    }


    steps = 1;

    while(!currentPosition.Equals(start))
    {
        switch (maze[currentPosition.Item1][currentPosition.Item2])
        {
            case '|': 
                currentPosition = (direction == 'S') ? new Tuple<int, int>(currentPosition.Item1 + 1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1 - 1,currentPosition.Item2);
                break;
            case '-':
               currentPosition = (direction == 'E') ? new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 + 1)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 -1);
                break;
            case 'L':
                currentPosition = (direction == 'W') ? new Tuple<int, int>(currentPosition.Item1 -1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 + 1);
                direction = (direction == 'W') ? 'N' : 'E';
                break;
            case 'J':
                currentPosition = (direction == 'E') ? new Tuple<int, int>(currentPosition.Item1 -1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 - 1);
                direction = (direction == 'E') ? 'N' : 'W';
                break;
            case '7':
                currentPosition = (direction == 'E') ? new Tuple<int, int>(currentPosition.Item1 +1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 - 1);
                direction = (direction == 'E') ? 'S' : 'W';
                break;
            case 'F':
                currentPosition = (direction == 'W') ? new Tuple<int, int>(currentPosition.Item1 + 1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 + 1);
                direction = (direction == 'W') ? 'S' : 'E';
                break;
                
        }
        steps++;      
    }
    return steps/2;
}


static long PartTwo()
{

    string? line;
    List<List<char>> maze = new List<List<char>>();
    int height = 0;
    int width = 0;
    Tuple<int,int> start = new Tuple<int, int>(0,0);
    bool foundStart = false;
    int numEnclosed =0;

    using(StreamReader sr = new StreamReader("input.txt"))
    {

        
        while((line = sr.ReadLine()) !=null)
        {
            List<char> row = line.ToCharArray().ToList();
            if(!foundStart)
            {
                if(line.IndexOf('S') != -1)
                {
                    start = new Tuple<int,int>(height,line.IndexOf('S'));
                    foundStart = true;
                }
            }
            maze.Add(row);
            height++;
        }

        width = maze[0].Count;

        //Console.WriteLine(new Tuple<int,int>(width,height));

        
        
    }

    HashSet<Tuple<int,int>> visited = new HashSet<Tuple<int, int>>();
    visited.Add(start);

    Tuple<int,int> currentPosition = start;
    //Console.WriteLine(start);
    bool foundNext = false;
    char direction = '*';

    List<Tuple<int,int>> validOffset = new List<Tuple<int, int>>{
        
        new Tuple<int, int>(1,0),
        new Tuple<int, int>(0,1),
        new Tuple<int, int>(0,-1),
        new Tuple<int, int>(-1,0),
        
        


    };
   foreach(var offset in validOffset){
        int i = currentPosition.Item1 + offset.Item1;
        int j = currentPosition.Item2 + offset.Item2;

        if( i < 0 || i > height -1 || j < 0 || j > width - 1) 
            continue;
        if(!".S".Contains(maze[i][j]))
        {
            currentPosition = new Tuple<int, int>(i,j);

            visited.Add(currentPosition);

            switch(maze[currentPosition.Item1][currentPosition.Item2])
            {
                case '|':
                    direction = (currentPosition.Item1 < start.Item1) ? 'N' : 'S';
                    break;
                case '-':
                    direction = (currentPosition.Item2 < start.Item2) ? 'W' : 'E';
                    break;
                case 'L':
                    direction  = (currentPosition.Item1 < start.Item1) ? 'N' : 'E';
                    break;
                case 'J':
                    direction = (currentPosition.Item2 > start.Item2) ? 'N' : 'W';
                    break;
                case '7':
                    direction = (currentPosition.Item1 > start.Item1) ? 'S' : 'W';
                    break;
                case 'F':
                    direction = (currentPosition.Item1 > start.Item1) ? 'S' : 'E';
                    break;


            }

            foundNext = true;
            break;
        }
       
        if(foundNext)
            break;
    }

    while(!currentPosition.Equals(start))
    {
        switch (maze[currentPosition.Item1][currentPosition.Item2])
        {
            case '|': 
                currentPosition = (direction == 'S') ? new Tuple<int, int>(currentPosition.Item1 + 1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1 - 1,currentPosition.Item2);
                break;
            case '-':
               currentPosition = (direction == 'E') ? new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 + 1)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 -1);
                break;
            case 'L':
                currentPosition = (direction == 'W') ? new Tuple<int, int>(currentPosition.Item1 -1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 + 1);
                direction = (direction == 'W') ? 'N' : 'E';
                break;
            case 'J':
                currentPosition = (direction == 'E') ? new Tuple<int, int>(currentPosition.Item1 -1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 - 1);
                direction = (direction == 'E') ? 'N' : 'W';
                break;
            case '7':
                currentPosition = (direction == 'E') ? new Tuple<int, int>(currentPosition.Item1 +1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 - 1);
                direction = (direction == 'E') ? 'S' : 'W';
                break;
            case 'F':
                currentPosition = (direction == 'W') ? new Tuple<int, int>(currentPosition.Item1 + 1,currentPosition.Item2)
                : new Tuple<int, int>(currentPosition.Item1,currentPosition.Item2 + 1);
                direction = (direction == 'W') ? 'S' : 'E';
                break;
                
        }
        if(!start.Equals(currentPosition))
            visited.Add(currentPosition);
             
    }
    maze[start.Item1][start.Item2] = 'F';
    for(int i = 0;i < maze.Count;i++)
    {
        for(int j =0;j< maze[0].Count; j++)
        {
            if(!visited.Contains(new Tuple<int, int>(i,j)))
                maze[i][j] = '.';
        }
    }

    using (StreamWriter sw = new StreamWriter("output.txt"))
    {
        for(int i = 0;i < maze.Count;i++)
        {
            string l = String.Join("",maze[i]);
            sw.WriteLine(l);
            
        }

        
    }


    List<string> cleanedMap = new();
    for(int i = 0; i <= maze.Count-1; i++)
    {
        StringBuilder sb = new();
        for(int j = 0; j<= maze[0].Count-1; j++)
        {
            sb.Append(maze[i][j]);
        }

        cleanedMap.Add(Regex.Replace(Regex.Replace(sb.ToString(), "F-*7|L-*J", string.Empty), "F-*J|L-*7", "|"));
    }

    numEnclosed = 0;

    foreach (string l in cleanedMap)
    {
        int parity = 0;
        foreach(var c in l)
        {
            if (c == '|') parity++;
            if (c == '.' && parity % 2 == 1) numEnclosed++;
        }
    }
    
    // for(int i = 0;i < maze.Count;i++)
    // {
    //     for(int j =0;j< maze[0].Count; j++)
    //     {
    //         if(maze[i][j] == '.')
    //         {
    //             var crossings  = CountCrossingsToEdge(i,j,maze);

    //             if( crossings % 2 == 1 ||crossings % 2 == -1)
    //             {
    //                 if(i == start.Item1)
    //                     Console.WriteLine($"({i},{j})");
    //                 numEnclosed++;
    //             }
    //         }

    //     }
    // }
    
    return numEnclosed;
}

static int CountCrossingsToEdge(int i, int j, List<List<char>> maze)
{
    int numCrossed = 0;
    for(int column = j;column >= 0;column --)
    {
        //"S|7JFL"
        if("JF".Contains(maze[i][column]))
        {
            
            numCrossed+= 1;
        }

        if("7L".Contains(maze[i][column]))
        {
            
            numCrossed-= 1;
        }



    }
    return (int)numCrossed;
}


// | is a vertical pipe connecting north and south.
// - is a horizontal pipe connecting east and west.
// L is a 90-degree bend connecting north and east.
// J is a 90-degree bend connecting north and west.
// 7 is a 90-degree bend connecting south and west.
// F is a 90-degree bend connecting south and east.
// . is ground; there is no pipe in this tile.
// S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.
