using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                int maxSeatId = 0;
                string line;
                List<int> seatIds = new List<int>();
                for(int i =1;i<127;i++)
                {
                    for(int j =0;j<8;j++)
                    {
                        seatIds.Add(i*8+j);
                    }
                }
                while ((line = sr.ReadLine()) != null)
                {
                   

                    int seatID = GetSeatID(line);
                    if(seatID > maxSeatId)
                    {
                        maxSeatId = seatID;
                    }
                    seatIds.Remove(seatID);

                                       
                }
                Console.WriteLine("max SeatId {0}",maxSeatId);
            }
            
        }

       

        static int GetSeatID(string seatString)
        {
            int minRow = 0;
            int maxRow = 127;
            int minColumn = 0;
            int maxColumn = 7;
            for(int i = 0;i<7;i++)
            {
                if(seatString[i]=='F')
                {
                    maxRow = (int)Math.Floor((minRow + maxRow)/2.0);
                }
                else
                {
                    minRow = (int)Math.Ceiling((minRow + maxRow)/2.0);
                }
            }
            for(int i = 7;i<10;i++)
            {
                if(seatString[i]=='L')
                {
                    maxColumn = (int)Math.Floor((minColumn + maxColumn)/2.0);
                }
                else
                {
                    minColumn = (int)Math.Ceiling((minColumn + maxColumn)/2.0);
                }
            }
            return minRow * 8 + minColumn;
        }
    }
}
