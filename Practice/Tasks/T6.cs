using System;
using System.Collections.Generic;

namespace Practice.Tasks
{
    public static class T6
    {
        private static Dictionary<char, char> pairs;

        static T6()
        {
            pairs = new Dictionary<char, char>
            {
                {'(', ')'},
                {'[', ']'},
                {'{', '}'},
                {'<', '>'}
            };
        }
        /// <summary>
        /// Сделать проверку правильной математической последовательности?
        /// То есть если первый элемент такой (, то последний обратный этому, то есть ).
        /// ({}[]) - не верная
        /// ({[})] - не верная
        /// ({[]}) - верная
        /// ({[}) - не верная (нечетное количество символов)
        /// </summary>
        public static bool Task(string line)
        {
            line = line.Replace(" ", "");
            if (line.Length % 2 != 0) return false;
            for (var i = 0; i < line.Length / 2; i++)
                if (line[^(i + 1)] != pairs[line[i]]) return false;
            return true;
        }
        
        /// <summary>//TODO: Сделать
        /// Сделать проверку правильной математической последовательности?
        /// То есть если первый элемент такой (, то последний обратный этому, то есть ).
        /// ({}[]) - не верная
        /// ({[})] - не верная
        /// ({[]}) - верная
        /// ({[}) - не верная (нечетное количество символов)
        /// </summary>
        public static bool TaskStack(string line)
        {
            var stack = new Stack<char>();
            foreach (var c in line)
            {
                
            }
            return true;
        }
    }
}