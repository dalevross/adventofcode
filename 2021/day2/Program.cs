using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int horizontalPos = 0;
            
            int verticalPos = 0;
            using(StreamReader sr = new StreamReader("input.txt"))
            {
               
                string instruction;
                while((instruction = sr.ReadLine()) != null)
                {
                    string[] instructions = instruction.Split(' ');
                    switch(instructions[0])
                    {
                        case "forward":
                           horizontalPos += Int32.Parse(instructions[1]);
                           break;
                        case "down":
                           verticalPos += Int32.Parse(instructions[1]);
                           break;
                           case "up":
                        verticalPos -= Int32.Parse(instructions[1]);
                           break;
                        default:
                            break;

;                    }
                }
            }
            Console.WriteLine("Result {0}",horizontalPos * verticalPos);

            horizontalPos = 0;
            
            verticalPos = 0;
            int aim = 0;
            using(StreamReader sr = new StreamReader("input.txt"))
            {
               
                string instruction;
                while((instruction = sr.ReadLine()) != null)
                {
                    string[] instructions = instruction.Split(' ');
                    switch(instructions[0])
                    {
                        case "forward":
                            horizontalPos += Int32.Parse(instructions[1]);
                            verticalPos += aim * Int32.Parse(instructions[1]);
                            break;
                        case "down":
                            aim += Int32.Parse(instructions[1]);
                            break;
                            case "up":
                            aim -= Int32.Parse(instructions[1]);
                            break;
                        default:
                            break;

;                    }
                }
            }

             Console.WriteLine("Result {0}",horizontalPos * verticalPos);
        }

    
    }

}
