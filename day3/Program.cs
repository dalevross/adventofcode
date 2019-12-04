using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wire1;
            string[] wire2;
            using (StreamReader sr = new StreamReader("input.txt"))
            {


                String line1 = sr.ReadLine();
                String line2 = sr.ReadLine();
                wire1 = line1.Split(new char[] { ',' });
                wire2 = line2.Split(new char[] { ',' });


            }
            Console.WriteLine(getDistances(new int[] { 0, 0 }, wire1, wire2));

        }

        static Tuple<int,int> getDistances(int[] startpoint, string[] wire1, string[] wire2)
        {
            int minManHattenDistance = Int32.MaxValue;
            int minTotalDistance = Int32.MaxValue;
            Dictionary<Tuple<int,int>,List<int>> referencePoints = new Dictionary<Tuple<int,int>, List<int>>();
            List<int[]> intersect = new List<int[]>();
            List<int[]> points1 = getPoints((int[])startpoint.Clone(), wire1);
            List<int[]> points2 = getPoints((int[])startpoint.Clone(), wire2);
            foreach(int[] point1 in points1)
            {
                 if(referencePoints.ContainsKey(new Tuple<int, int>(point1[0],point1[1])))
                    referencePoints[new Tuple<int, int>(point1[0],point1[1])].Add(point1[2]);
                 else
                    referencePoints.Add(new Tuple<int, int>(point1[0],point1[1]),new List<int>{point1[2]});
                
            }

            foreach(int[] point2 in points2)
            {
                if(referencePoints.ContainsKey(new Tuple<int, int>(point2[0],point2[1])))
                {
                    foreach(int distanceforwire1 in referencePoints[new Tuple<int, int>(point2[0],point2[1])])
                    {
                        intersect.Add(new int[]{point2[0],point2[1],distanceforwire1 + point2[2]});
                    }
                }
                    
            }
            //int minDistance = Int32.MaxValue;
            foreach(int[] point in intersect)
            {
                if(point[2] < minTotalDistance)
                    minTotalDistance = point[2];

                int manhattenDistance = Math.Abs(point[1] - startpoint[1]) + Math.Abs(point[0] - startpoint[0]);
                if(manhattenDistance < minManHattenDistance)
                {
                    minManHattenDistance = manhattenDistance;
                }
            }
            return new Tuple<int, int>(minManHattenDistance,minTotalDistance);
        }

        
        static List<int[]> getPoints(int[] startpoint, string[] wire)
        {
            int[] currentPoint = (int[])startpoint.Clone();
            List<int[]> points = new List<int[]>();
            int totalCount = 0;
            foreach (string movement in wire)
            {
                char dir = movement[0];
                int count = Int32.Parse(movement.Substring(1));
                switch (movement[0])
                {
                    case 'R':
                        foreach (int i in Enumerable.Range(currentPoint[0] + 1, count))
                        {
                            if(!(new int[] { i, currentPoint[1] }.SequenceEqual(new int[]{0,0})))
                                points.Add(new int[] { i, currentPoint[1],++totalCount });

                        }
                        currentPoint[0] += count;
                        break;
                    case 'L':
                        foreach (int i in Enumerable.Range(currentPoint[0] - count, count).Reverse())
                        {
                            if(!(new int[] { i, currentPoint[1] }.SequenceEqual(new int[]{0,0})))
                                points.Add(new int[] { i, currentPoint[1] ,++totalCount});

                        }
                        currentPoint[0] -= count;
                        break;
                    case 'U':
                        foreach (int i in Enumerable.Range(currentPoint[1] + 1, count))
                        {
                            if(!(new int[] { currentPoint[0], i }.SequenceEqual(new int[]{0,0})))
                                points.Add(new int[] { currentPoint[0], i ,++totalCount});

                        }
                        currentPoint[1] += count;
                        break;
                    case 'D':
                        foreach (int i in Enumerable.Range(currentPoint[1] - count, count).Reverse())
                        {
                            if(!(new int[] { currentPoint[0], i }.SequenceEqual(new int[]{0,0})))
                                points.Add(new int[] { currentPoint[0], i,++totalCount });

                        }
                        currentPoint[1] -= count;
                        break;

                }


            }
            return points;

        }
    }
}
