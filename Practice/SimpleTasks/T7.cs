using System;
using System.Linq;

namespace Practice.SimpleTasks
{
    public class T7
    {
        /// <summary>
        /// Введите с клавиатуры строку произвольной длины и подсчитайте процент вхождения заданного символа в строку
        /// </summary>
        public static void Task()
        {
            string s = null;
            while(string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("Введите строку");
                s = Console.ReadLine();
            }
            Console.WriteLine("Введите символ");
            char symbol;
            while (!char.TryParse(Console.ReadLine(), out symbol))
            {
                Console.WriteLine("Ошибка: нужно ввести символ");
                Console.WriteLine("Введите символ");
            }
            var count = s.Count(c => symbol == c);
            if (count != 0) Console.WriteLine(Math.Round((double) count / s.Length * 100)); 
            else Console.WriteLine("Символов нет");
        }
    }
}