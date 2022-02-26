using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            var sum = GetSequence(1, 2, 4000000).Where(x => x % 2 == 0).Sum();
        }

        private static IEnumerable<int> GetSequence(int first, int second, int max)
        {
            yield return first;
            yield return second;
            int next = first + second;
            while (next < max)
            {
                yield return next;
                first = second;
                int tmp = second;
                second = next;
                next += tmp;
            }
        }
    }
}