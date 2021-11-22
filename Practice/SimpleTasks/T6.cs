using System;

namespace Practice.SimpleTasks
{
    public class T6
    {
        /// <summary>
        /// Напишите программу в которой есть класс с символьным свойством.
        /// Опишите аксессоры для свойства так чтобы значение свойства попадало в диапазон символов от A о Z.
        /// </summary>
        public static void Task()
        {
            A a = new A();
            Console.WriteLine(a.Symbol);
            a.Symbol = '2';
            Console.WriteLine(a.Symbol);
            a.Symbol = 'P';
            Console.WriteLine(a.Symbol);
            a.Symbol = 'p';
            Console.WriteLine(a.Symbol);
        }
    }

    internal class A
    {
        private char _symbol;
        public char Symbol
        {
            get => _symbol;
            set
            {
                if (value is >= 'A' and <= 'Z')
                {
                    _symbol = value;
                }
                else
                {
                    Console.WriteLine("Не входит в диапазон ['A';'Z']");
                }
            }
        }
    }
}