using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                string[] bits = sr.ReadToEnd().Split('\n');
                bits = bits.Select(x => x.Trim()).ToArray<string>();
                
                String gammaRate = getGammaRate(bits);
                String epsilonRate = getEpsilonRate(bits);
                Console.WriteLine(Convert.ToInt32(gammaRate, 2) 
                * Convert.ToInt32(epsilonRate, 2) );

                String oxygenRating =  getOxygenGeneraterRating(bits);
                String cO2ScrubberRating = getCO2ScrubberRating(bits);
                  Console.WriteLine(Convert.ToInt32(oxygenRating, 2) 
                * Convert.ToInt32(cO2ScrubberRating, 2) );


                
            }
           
        }


        static string getGammaRate(string[] bits)
        {
            StringBuilder gammaRate = new StringBuilder();
            for(int i = 0;i<bits[0].Length;i++)
            {
                    char gammaRateI = ( bits.Select(x=>x[i]).Count(c => c == '1') >= (0.5 * bits.Length))? '1' : '0';
                    gammaRate.Append(gammaRateI);
            }
            return gammaRate.ToString();
        }

        static string getEpsilonRate(string[] bits)
        {
            StringBuilder epsilonRate = new StringBuilder();
            for(int i = 0;i<bits[0].Length;i++)
            {
                    char epsilonRateI = ( bits.Select(x=>x[i]).Count(c => c == '0') <= (0.5 * bits.Length))? '0' : '1';
                    epsilonRate.Append(epsilonRateI);
            }
            return epsilonRate.ToString();
        }

        static string getOxygenGeneraterRating(string[] bits)
        {
            int index = 0;
            while(bits.Length > 1)
            {
                string gammaRate = getGammaRate(bits);
                bits = bits.Where(bit => bit[index] == gammaRate[index]).ToArray<string>();
                index++;
            }
            return bits[0];
        }

        static string getCO2ScrubberRating(string[] bits)
        {
            int index = 0;
            while(bits.Length > 1)
            {
                string epsilonRate = getEpsilonRate(bits);
                bits = bits.Where(bit => bit[index] == epsilonRate[index]).ToArray<string>();
                index++;
            }
            return bits[0];
        }


    }
}
