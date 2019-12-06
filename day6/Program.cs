using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;


namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> dOrbits = new Dictionary<string, string>();
            
            string line;
            using (StreamReader sr = new StreamReader("input.txt"))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    string[] orbits = line.Split(new char[] { ')' });
                    dOrbits.Add(orbits[1], orbits[0]);
                   

                }
                Console.WriteLine(Process(dOrbits, "COM"));
                Console.WriteLine(TimeToObject(dOrbits,"YOU", "SAN"));
                

            }
        }

        static int TimeToObject(  Dictionary<string, string> dOrbits,string traveler, string targetObject)
        {

            int count = 0;
            List<string> targetList = new List<string>();
            List<string> travelerList = new List<string>();

            foreach (var item in dOrbits)
            {
                string startingObject = item.Key;
                string currentObject = startingObject;

                do
                {
                    if(startingObject == traveler)
                    { 
                        travelerList.Add(dOrbits[currentObject]); 
                        count++;
                    }
                    else if(startingObject == targetObject){
                        targetList.Add(dOrbits[currentObject]);
                        count++;
                    }
                    currentObject  = dOrbits[currentObject];
                    
                } while (currentObject != "COM");
            }

            string commonAncestor = targetList.Intersect(travelerList).First();
            travelerList.Reverse();
            return count - (2 * (travelerList.IndexOf(commonAncestor) + 1));

            
        }

        


        static int Process(Dictionary<string, string> toOrbits, string target)//, Dictionary<string,List<string>> fromOrbits)
        {
            int total = 0;
            foreach (var item in toOrbits)
            {
                string directOrbit = item.Key;
                do
                {
                    total++;
                    directOrbit = toOrbits[directOrbit];
                } while (directOrbit != target);


            }

            return total;
        }
    }
}
