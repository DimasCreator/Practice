using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Practice.PracticeLINQ
{
    public static class UlearnLinq
    {
        /// <summary>
        /// Каждая строка либо пустая, либо содержит одно целое число. вернуть массив чисел
        /// </summary>
        public static int[] Task1(IEnumerable<string> lines)
        {
            return lines.Where(l => !string.IsNullOrEmpty(l)).Select(int.Parse).ToArray();
        }
        
        /// <summary>
        /// В каждой строке написаны две координаты точки (X, Y), разделенные пробелом.
        /// Реализуйте метод создающий из строк объекты Point в одно LINQ-выражение.
        /// Постарайтесь не использовать функцию преобразования строки в число более одного раза.
        /// </summary>
        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X, Y;
        }
        public static Point[] Task2(IEnumerable<string> lines)
        {
            return lines.Select(l => l.Split(' '))
                .Select(p => new Point(int.Parse(p[0]), int.Parse(p[1])))
                .ToArray();
        }
        public static IEnumerable<Point> Task3(Point p)
        {
            int[] d = {-1, 0, 1};
            return d.SelectMany(dx => d.Select(dy => new Point(p.X + dx, p.Y + dy)))//для каждого dx проходимся по dy
                .Where(point => !point.Equals(p));
        }
        
        /// <summary>
        /// Вам дан список всех классов в школе. Нужно получить список всех учащихся всех классов.
        /// Напишите решение этой задачи с помощью LINQ в одно выражение.
        /// </summary>
        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
        public static string[] Task4(Classroom[] classes)
        {
            return classes.SelectMany(c => c.Students).ToArray();
        }
        
        /// <summary>
        /// Текст задан массивом строк. Вам нужно составить лексикографически упорядоченный список всех встречающихся в этом тексте слов.
        /// Слова нужно сравнивать регистронезависимо, а выводить в нижнем регистре.
        /// </summary>
        public static string[] Task5(params string[] textLines)
        {
            return textLines.SelectMany(l => Regex.Split(l, @"\W+"))
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w=>w.ToLower())
                .Distinct()
                .OrderBy(w=>w)
                .ToArray();
        }
        
        
    }
}