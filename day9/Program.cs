using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            long step1 = 0;
            long[] ints;
            using (StreamReader sr = new StreamReader("sample.txt"))
            {
                string line;
                line = sr.ReadLine();
                string[] strs = line.Split(new char[] { ',' });
                var list = strs.Select(x => long.Parse(x)).ToList();
                //Extra memory
                list.AddRange(Enumerable.Repeat<long>(0,1000));
                ints = list.ToArray();
                step1 = Step1((long[])ints.Clone(), 1);
                

            }


        }

        static long Step1(long[] ints, int input)
        {
            int relativebase = 0;

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

                var p1 = (param1mode == 0) ? ints[param1] : param1mode == 1 ? param1 : ints[param1 + relativebase];
                var p2 = (param2mode == 0) ? ints[param2] : param2mode == 1 ? param2 : ints[param2 + relativebase];
                //var p3 = (param2mode == 0) ? ints[param2] : param3mode == 1 ? param3 : ints[param3 + relativebase];
                    


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
                        ints[p1] = input;
                        i += 2;
                        break;
                    case 4:
                        Console.WriteLine(ints[p1]);
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
                        relativebase += (int)param1;
                        i += 2;
                        break;

                }


            }

            return ints[0];
        }

        static void SetupInstructions(long[] instructions, long noun, long verb)
        {
            instructions[1] = noun;
            instructions[2] = verb;
        }



        static int Step2(long[] ints, int target)
        {
            long[] localints;
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    localints = (long[])ints.Clone();
                    SetupInstructions(localints, noun, verb);
                    if (Step1(localints, 1) == target)
                    {
                        return 100 * noun + verb;
                    }


                }

            }
            return 0;
        }
    }
}
