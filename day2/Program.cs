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
            var step1 = 0;
            var step2 = 0;
            int[] ints;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                line = sr.ReadLine();
                string[] strs = line.Split(new char[] { ',' });
                ints = strs.Select(x => Int32.Parse(x)).ToArray();
                int[] ints2 = (int[])ints.Clone();
                SetupInstructions(ints, 12, 2);
                
                step1 = Step1(ints);
                step2 = Step2(ints2,19690720);


            }

            Console.WriteLine(step1);
            Console.WriteLine(step2);
        }

        static int Step1(int[] ints)
        {
            for (int i = 0; ints[i] != 99 && i < ints.Length; i += 4)
            {
                int opcode = ints[i];
                int param1 = ints[i + 1];
                int param2 = ints[i + 2];
                int updateindex = ints[i + 3];
                if(param1 < ints.Length &&  param2 < ints.Length && updateindex <ints.Length)
                {
                    switch (opcode)
                    {
                        case 1:
                            ints[updateindex] = ints[param1] + ints[param2];
                            break;
                        case 2:
                            ints[updateindex] = ints[param1] * ints[param2];
                            break;

                    }
                }
                else
                    return -1;
            }

            return ints[0];
        }

        static void SetupInstructions(int[] instructions, int noun, int verb)
        {
            instructions[1] = noun;
            instructions[2] = verb;
        }



        static int Step2(int[] ints,int target)
        {
            int[] localints;
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    localints = (int[])ints.Clone();
                    SetupInstructions(localints,noun,verb);
                    if(Step1(localints) == target)
                    {
                        return 100 * noun + verb;
                    }


                }

            }
           return 0;
        }
    }
}
