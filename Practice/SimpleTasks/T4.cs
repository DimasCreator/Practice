using System;
using System.Text;

namespace Practice.SimpleTasks
{
    public class T4
    {
        /// <summary>
        /// Пользователь вводит символ и количество раз, сколько этот символ должен вывестись.
        /// Затем выводится строка, состоящая из символа, введённого пользователем, столько раз, сколько пользователь указал.
        /// </summary>
        public static void Task()
        {
            Console.WriteLine("Введите символ");
            char c = ' ';
            while (!char.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Неверное значение для символа\nВведите символ");
            }

            int count = 0;
            Console.WriteLine("Введите количество символов в результирующей строке");
            while (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("Неверное значение для целого числа\nВведите число");
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(c);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}