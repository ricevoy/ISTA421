using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> pointsList = new List<Point>();
            for (int i = 0; i < 100; i++)
            {
                pointsList.Add(Point.RandomVector(i, i + 25));
            }

            Point[] a = new Point[2];
            a = Point.ShortestDist(pointsList);

            Console.WriteLine("The two points that have the shortest distance between them are:");
            foreach (Point v in a)
            {
                Console.WriteLine($"({v.x},{v.y},{v.z})");
            }
        }
    }
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public static double Distance(Point A, Point B)
        {
            return Math.Sqrt((Math.Pow(B.x - A.x, 2) + (Math.Pow(B.y - A.y, 2)) + (Math.Pow(B.z - A.z, 2))));
        }

        public static Point RandomVector(int twoD)
        {
            Point vector = new Point();
            Random rnd = new Random();
            int x = rnd.Next(100) + twoD;
            int y = rnd.Next(100) - twoD;
            vector.x = x;
            vector.y = y;
            return vector;
        }
        public static Point RandomVector(int twoD, int threeD)
        {
            Point vector = new Point();
            Random rnd = new Random();
            int x = rnd.Next(100) + twoD;
            int y = rnd.Next(100) - twoD;
            int z = rnd.Next(100) + threeD;
            vector.x = x;
            vector.y = y;
            vector.z = z;
            return vector;
        }

        public static Point[] ShortestDist(List<Point> vectorList)
        {
            double lowest = Distance(vectorList[0], vectorList[1]);

            Point[] result = new Point[2];

            for (int i = 0; i < vectorList.Count; i++)
            {
                for (int j = i + 1; j < vectorList.Count; j++)
                {
                    double dist = Distance(vectorList[i], vectorList[j]);
                    if (dist < lowest)
                    {
                        lowest = dist;
                        result[0] = vectorList[i];
                        result[1] = vectorList[j];
                    }
                }
            }
            return result;
        }
    }
}