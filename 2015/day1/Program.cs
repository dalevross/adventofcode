using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
           using(StreamReader streamReader= new StreamReader("input.txt"))
           {
               
              string line = streamReader.ReadToEnd();
              int floor = 0;
              bool bPrinted = false;
              for(int i = 0;i<line.Length;i++)
              {
                  if(line[i]=='(')
                  {
                      floor++;
                  }
                  else
                  {
                      floor--;
                  }
                  if(floor==-1 && !bPrinted)
                  {
                      Console.WriteLine("First Basement {0}",i+1);
                      bPrinted = true;
                  }
              }
              Console.WriteLine("Floor {0}",floor);

           }
        }
    }
}
