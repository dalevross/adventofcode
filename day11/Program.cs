using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace day11
{
    class Program
    {
        static int paintedPanels = 0;
        static char currentDirection = '^';
        static void Main(string[] args)
        {
            long step1 = 0;
            long[] ints;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                line = sr.ReadLine();
                string[] strs = line.Split(new char[] { ',' });
                var list = strs.Select(x => long.Parse(x)).ToList();
                //Extra memory
                list.AddRange(Enumerable.Repeat<long>(0,200000));
                ints = list.ToArray();
                Paint((long[])ints.Clone(), 2);
                Console.WriteLine(paintedPanels);
                

            }


        }

        static void Paint(long[] ints, int input)
        {
            Dictionary<Tuple<int,int>,int> painted = new Dictionary<Tuple<int, int>, int>();
            int relativebase = 0;
            int currentPaint = 0;
            int currentOutput = 0;
            
            Tuple<int,int> currentPoint = new Tuple<int, int>(0,0);

            for (int i = 0; ints[i] != 99 && i < ints.Length;)
            {
                
                long opcode = ints[i];
                long param1 = ints[i + 1];
                long param2 = ints[i + 2];
                long updateindex = ints[i + 3];
                string opcodeFilled = opcode.ToString().PadLeft(5, '0');
                //Console.WriteLine(opcodeFilled);
                long param1mode = int.Parse(opcodeFilled[2].ToString());
                long param2mode = int.Parse(opcodeFilled[1].ToString());
                long param3mode = int.Parse(opcodeFilled[0].ToString());
                opcode = int.Parse(opcodeFilled.Substring(3));

                long p1,p2 = 0;

                if(opcode == 3)
                {
                    p1 = (param1mode == 0)? param1:param1 + relativebase;
                   
                }
                else if(opcode == 4){
                    p1 = (param1mode == 0) ? ints[param1] : param1mode == 1 ? param1 : ints[param1 + relativebase];

                }
                else
                {
                    p1 = (param1mode == 0) ? ints[param1] : param1mode == 1 ? param1 : ints[param1 + relativebase];
                    p2 = (param2mode == 0) ? ints[param2] : param2mode == 1 ? param2 : ints[param2 + relativebase];
                }

                updateindex =   (param3mode == 0)? updateindex: updateindex + relativebase;   
              

                switch (opcode)
                {
                    case 1:
                        ints[updateindex] = p1 + p2;
                        i += 4;
                        break;
                    case 2:
                        ints[updateindex] = p1 * p2;
                        i += 4;
                        break;
                    case 3:
                        if(painted.ContainsKey(currentPoint))
                            currentPaint = painted[currentPoint];
                        else
                            currentPaint = 0;
                        ints[p1] = currentPaint;
                        i += 2;
                        break;
                    case 4:
                        /*Process Output*/
                        if(currentOutput % 2 == 0)
                        {
                            if(painted.ContainsKey(currentPoint))
                                painted[currentPoint] = (int)p1;
                            else
                            {
                                painted.Add(currentPoint,(int)p1);
                                paintedPanels++;

                            }
 
                        }
                        else{
                            currentPoint = GetNextPoint(currentPoint,(int)p1);

                        }
                        currentOutput++;
                        Console.WriteLine(p1);
                        i += 2;
                        break;
                    case 5:
                        if (p1 != 0)
                            i = (int)p2;
                        else
                            i += 3;                       
                        break;
                    case 6:
                        if (p1 == 0)
                            i = (int)p2;
                        else
                            i += 3;                       
                        break;
                    case 7:                    
                        ints[updateindex] = (p1 < p2) ? 1 : 0;
                        i += 4;                        
                        break;
                    case 8:                      
                        ints[updateindex] = (p1 == p2) ? 1 : 0;
                        i += 4;
                        break;
                     case 9:
                        relativebase += (int)p1;
                        i += 2;
                        break;

                }


            }

            
        }

        static Tuple<int,int> GetNextPoint( Tuple<int,int> currentPoint, int leftOrRight)
        {
            Tuple<int,int> nextPoint = new Tuple<int,int>(0,0);
            switch (currentDirection)
            {
                case '^':
                    nextPoint = (leftOrRight == 0)? new Tuple<int, int>(currentPoint.Item1,currentPoint.Item2 - 1):new Tuple<int, int>(currentPoint.Item1,currentPoint.Item2 + 1);
                    currentDirection = (leftOrRight == 0)? '<': '>';
                    break;
                 case 'V':
                    nextPoint = (leftOrRight == 0)? new Tuple<int, int>(currentPoint.Item1,currentPoint.Item2 + 1):new Tuple<int, int>(currentPoint.Item1,currentPoint.Item2 -1);
                    currentDirection = (leftOrRight == 0)? '>': '<';
                    break;
                case '>':
                    nextPoint = (leftOrRight == 0)? new Tuple<int, int>(currentPoint.Item1 + 1,currentPoint.Item2):new Tuple<int, int>(currentPoint.Item1 -1,currentPoint.Item2);
                    currentDirection = (leftOrRight == 0)? '^': 'V';
                    break;
                 case '<':
                    nextPoint = (leftOrRight == 0)? new Tuple<int, int>(currentPoint.Item1 -1 ,currentPoint.Item2):new Tuple<int, int>(currentPoint.Item1 + 1,currentPoint.Item2);
                    currentDirection = (leftOrRight == 0)? 'V': '^';
                    break;
                
            
            }

            return nextPoint;

        }

      


       
    }
}
