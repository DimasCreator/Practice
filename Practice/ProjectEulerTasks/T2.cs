using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Practice.ProjectEulerTasks
{
    /// <summary>
    /// Каждый новый член в последовательности Фибоначчи генерируется путем добавления двух предыдущих членов.
    /// Начиная с 1 и 2, первые 10 терминов будут: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    /// Рассматривая термины в последовательности Фибоначчи, значения которых не превышают четырех миллионов, найдите сумму четных членов.
    /// </summary>
    public static class T2
    {
        public static void Task()
        {
            foreach (var fNum in GetSequence(4000000))
            {
                Console.WriteLine(fNum);
            }
            Console.WriteLine("Сумма: " + GetSequence(4000000).Where(i => i % 2 == 0).Sum());
        }

        private static IEnumerable<int> GetSequence(int max)
        {
            var sequence = new LinkedList<int>();
            sequence.AddLast(1);
            sequence.AddLast(2);
            var next = sequence.Last.Value + sequence.Last.Previous.Value;
            while (next < max)
            {
                sequence.AddLast(next);
                next = sequence.Last.Value + sequence.Last.Previous.Value;
            }
            return sequence;
        }
    }
}