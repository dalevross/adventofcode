using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var step1 = 0;
            var step2 = 0;
            int[] ints;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                line = sr.ReadLine();
                string[] strs = line.Split(new char[] { ',' });
                ints = strs.Select(x => Int32.Parse(x)).ToArray();

                step1 = Step1((int[])ints.Clone(), 5);
                //step2 = Step1((int[])ints.Clone(),5);


            }


        }

        static int Step1(int[] ints, int input)
        {
            for (int i = 0; ints[i] != 99 && i < ints.Length;)
            {
                int opcode = ints[i];
                int param1 = ints[i + 1];
                int param2 = ints[i + 2];
                int updateindex = ints[i + 3];
                string opcodeFilled = opcode.ToString().PadLeft(5, '0');
                //Console.WriteLine(opcodeFilled);
                int param1mode = int.Parse(opcodeFilled[2].ToString());
                int param2mode = int.Parse(opcodeFilled[1].ToString());
                int param3mode = int.Parse(opcodeFilled[0].ToString());
                opcode = int.Parse(opcodeFilled.Substring(3));




                switch (opcode)
                {
                    case 1:
                        ints[updateindex] = ((param1mode == 0) ? ints[param1] : param1) + ((param2mode == 0) ? ints[param2] : param2);
                        Console.WriteLine($"{opcodeFilled} {param1} {param2} {updateindex} {ints[updateindex]}");
                        i += 4;
                        break;
                    case 2:
                        ints[updateindex] = ((param1mode == 0) ? ints[param1] : param1) * ((param2mode == 0) ? ints[param2] : param2);
                        Console.WriteLine($"{opcodeFilled} {param1} {param2} {updateindex} {ints[updateindex]}");
                        i += 4;
                        break;
                    case 3:
                        Console.WriteLine($"{opcodeFilled} {param1}");
                        ints[param1] = input;
                        i += 2;
                        break;
                    case 4:
                        Console.WriteLine($"{opcodeFilled} {param1}");
                        Console.WriteLine(ints[param1]);
                        i += 2;
                        break;
                    case 5:
                        Console.WriteLine($"{opcodeFilled} {param1} {param2}");
                        {
                            int param1Val = ((param1mode == 0) ? ints[param1] : param1);
                            int param2Val = ((param2mode == 0) ? ints[param2] : param2);
                            if (param1Val != 0)
                                i = param2Val;
                            else
                                i += 3;
                        }
                        break;
                    case 6:
                        Console.WriteLine($"{opcodeFilled} {param1} {param2}");
                        {
                            int param1Val = ((param1mode == 0) ? ints[param1] : param1);
                            int param2Val = ((param2mode == 0) ? ints[param2] : param2);
                            if (param1Val == 0)
                                i = param2Val;
                            else
                                i += 3;
                        }
                        break;
                    case 7:
                        Console.WriteLine($"{opcodeFilled} {param1} {param2} {updateindex} {ints[updateindex]}");

                        {
                            int param1Val = ((param1mode == 0) ? ints[param1] : param1);
                            int param2Val = ((param2mode == 0) ? ints[param2] : param2);

                            ints[updateindex] = (param1Val < param2Val) ? 1 : 0;

                            i += 4;
                        }
                        break;
                    case 8:
                        Console.WriteLine($"{opcodeFilled} {param1} {param2} {updateindex} {ints[updateindex]}");

                        {
                            int param1Val = ((param1mode == 0) ? ints[param1] : param1);
                            int param2Val = ((param2mode == 0) ? ints[param2] : param2);

                            ints[updateindex] = (param1Val == param2Val) ? 1 : 0;
                        }

                        i += 4;
                        break;

                }


            }

            return ints[0];
        }

        static void SetupInstructions(int[] instructions, int noun, int verb)
        {
            instructions[1] = noun;
            instructions[2] = verb;
        }



        static int Step2(int[] ints, int target)
        {
            int[] localints;
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    localints = (int[])ints.Clone();
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
