using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            using( StreamReader sr = new StreamReader("input.txt"))
            {
                int[] numbers = sr.ReadLine().Split(',').Select(x => Int32.Parse(x)).ToArray();
                List<Tuple<int,bool>[,]> boards = new List<Tuple<int,bool>[,]>();
                string row;
                while((row = sr.ReadLine())!=null)
                {
                    Tuple<int,bool>[,] board = new Tuple<int,bool>[5,5];
                       
                    for(int i = 0;i < 5;i++ )
                    {
                       row = sr.ReadLine();
                       int[] rowNums = row.Split(' ').Where(x => x!="").Select(x => Int32.Parse(x)).ToArray();;
                       for(int j = 0; j < 5; j++)
                       {
                           board[i,j] = new Tuple<int,bool>(rowNums[j],false);
                       }
                    }
                    boards.Add(board);
                }
                
                bool[] wonBoards = Enumerable.Repeat(false, boards.Count).ToArray();;
                        
                foreach(int calledNumber in numbers)
                {
                    foreach(var board in boards)
                    {
                        int boardIndex = boards.IndexOf(board);
                        if(!wonBoards[boardIndex])
                        {
                            Play(board,calledNumber);
                            if(BoardWon(board))
                            {
                                wonBoards[boardIndex] = true;
                                if(wonBoards.All(x => x == true))
                                {
                                    Console.WriteLine(GetSumUncalled(board) * calledNumber);
                                    return;
                                }
                            }
                        }                     
                    }
              
                }

            }
        }

        static void Play(Tuple<int,bool>[,] board,int calledNumber)
        {
            for(int i=0;i<5;i++)
            {
                for(int j = 0;j<5;j++)
                {
                    if(board[i,j].Item1 == calledNumber)
                        board[i,j] = new Tuple<int, bool>(calledNumber,true);
                }
            }
        }

        static bool BoardWon(Tuple<int,bool>[,] board)
        {
            int[] rowSums = new int[5]{0,0,0,0,0};
            int[] columnSums = new int[5]{0,0,0,0,0};
            for(int i = 0;i< 5;i++)
            {
                for(int j = 0;j < 5; j++)
                {
                    if(board[i,j].Item2)
                    {
                        rowSums[i]++;
                        columnSums[j]++;
                    }
                }
            }

            return rowSums.Any(x => x == 5) || columnSums.Any(x => x == 5);
        }

        static int GetSumUncalled(Tuple<int,bool>[,] board)
        {
            int sum = 0;
            for(int i=0;i<5;i++)
            {
                for(int j = 0;j<5;j++)
                {
                    if(board[i,j].Item2 == false)
                        sum = sum +board[i,j].Item1; 
                }
            }
            return sum;
        }
    }
}
