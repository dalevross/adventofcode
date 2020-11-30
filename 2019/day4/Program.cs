using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {


            int count1 = 0;
            int count2 = 0;
            Regex r = new Regex(@"(\d)\1");
            Regex r2 = new Regex(@"^(?!.*(\d)\1{2}).*$");
            Regex r3 = new Regex(@"(\d)\1{2,}");
            Regex r4 = new Regex(@"^(?=.*(\d)\1{2}).*$");
            for (int i = 382345; i <= 843167; i++)
            {
                string num = i.ToString();

                bool isascending = true;
                if (r.IsMatch(num))
                {




                    for (int j = 1; j < num.Length; j++)
                    {
                        if (num[j] < num[j - 1])
                            isascending = false;

                    }
                    if (isascending)
                    {
                        count1++;
                        if (r2.IsMatch(num))
                        {
                            if (r.IsMatch(r3.Replace(num, "")))
                            {
                                count2++;


                            }


                        }
                        else
                        {
                            if (r.IsMatch(r3.Replace(num, "")))
                            {
                                count2++;


                            }
                        }





                    }
                }
            }
            Console.WriteLine(count1);
            Console.WriteLine(count2);

        }
    }
}
