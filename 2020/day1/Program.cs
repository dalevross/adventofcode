using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,int> items = new Dictionary<int, int>();
            List<int> addends = new List<int>();
            using(StreamReader streamReader = new StreamReader("input.txt"))
            {
                String line;
                while((line = streamReader.ReadLine()) !=null)
                {
                    addends.Add(Int32.Parse(line));
                }
            }
            for(int i =0; i<addends.Count;i++)
            {
                for(int j = 0;j < addends.Count;j++)
                if(i!=j)
                {
                    if(addends.Contains(2020 - (addends[i]+addends[j])))
                    {
                        int index = addends.LastIndexOf(2020-(addends[i]+addends[j]));
                        Console.WriteLine("Product {0}", addends[i]*addends[index]*addends[j]);
                        break;
                    }
                }
           

            }
        }
    }
}
