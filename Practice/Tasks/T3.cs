using System;
using System.Collections.Generic;
using static System.Math;

namespace Practice.Tasks
{
    public static class T3
    {
        /// <summary>
        /// На данных n точек на плоскости найдите все тройки точек, которые образуют равносторонние треугольники.
        /// </summary>
        public static void Task()
        {
            Point[] points =
            {
                new(2.3, 3.1),
                new(2.6, 7.8),
                new(5.2, 1.4),
                new(7.1, 2.4),
                new(3.1, 5.3),
                new(0.0, 0.0),
                new(5, 0.0),
                new(2.5, Sqrt(25 - 6.25))
            };
            List<List<Point>> answers = new List<List<Point>>();
            for (var i = 0; i < points.Length; i++)
            {
                for (var j = i + 1; j < points.Length; j++)
                {
                    for (var k = j + 1; k < points.Length; k++)
                    {
                        if (IsEquilateralTriangle(points[i], points[j], points[k]))
                        {
                            answers.Add(new List<Point>());
                            answers[^1].Add(points[i]);
                            answers[^1].Add(points[j]);
                            answers[^1].Add(points[k]);
                        }
                    }
                }
            }

            foreach (var answerSet in answers)
            {
                Console.WriteLine("Точка");
                Console.WriteLine(answerSet[0].X + ", " + answerSet[0].Y);
                Console.WriteLine(answerSet[1].X + ", " + answerSet[1].Y);
                Console.WriteLine(answerSet[2].X + ", " + answerSet[2].Y);
                Console.WriteLine();
            }
        }

        private static bool IsEquilateralTriangle(Point p1, Point p2, Point p3)
        {
            double l1 = Point.Lenght(p1, p2);
            double l2 = Point.Lenght(p1, p3);
            double l3 = Point.Lenght(p2, p3);
            return l1 == l2 && l1 == l3;
        }
        
        private class Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public static double Lenght(Point p1, Point p2)
            {
                return Sqrt(Pow((p1.X - p2.X), 2) + Pow((p1.Y - p2.Y), 2));
            }
        }
    }
}