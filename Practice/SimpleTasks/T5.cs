using System;
using System.Linq;

namespace Practice.SimpleTasks
{
    public class T5
    {
        /// <summary>
        /// Дано: Массив целых чисел, в котором каждое число встречается два раза, и лишь одно число 1 раз.
        /// Надо: Найти это число.
        /// </summary>
        public static void Task()
        {
            int[] sequence = {1, 2, 3, 4, 65, 4, 3, 2, 1};
            var single = sequence.Aggregate(0, (acc, num) => acc ^ num); // TODO: почитать про XOR (в C# можно)
            Console.WriteLine(single);
        }
    }
}