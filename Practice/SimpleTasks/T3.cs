using System.Collections.Generic;
using System;
using System.Linq;

namespace Practice.SimpleTasks
{
    public class T3
    {
        // CodeBlog	#Task 908. Д
        // Два нечетных простых числа, отличающиеся на 2, называются близнецами.
        // Например, числа 5 и 7. Напишите программу, которая будет находить все числа-близнецы на отрезке [2; 1000].
        public static void Task()
        {
            IList<int> simpleList = GetSimpleList();
            LinkedList<TwinsPair> twinsPairs = new LinkedList<TwinsPair>();
            for (int i = 0; i < simpleList.Count - 1; i++)
            {
                if (simpleList[i] == simpleList[i + 1] - 2)
                {
                    twinsPairs.AddLast(new TwinsPair(simpleList[i], simpleList[i + 1]));
                }
            }
            foreach (var twins in twinsPairs)
            {
                Console.WriteLine(twins.First + " " + twins.Second);
            }
        }
        private static IList<int> GetSimpleList()
        {
            LinkedList<int> simpleList = new LinkedList<int>();
            for (int i = 2; i <= 1000; i++)
            {
                if (IsSimple(i))
                {
                    simpleList.AddLast(i);
                }
            }
            return simpleList.ToArray();
        }
        private static bool IsSimple(int number)
        {
            double sqrt = Math.Sqrt(number);
            for(int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        struct TwinsPair
        {
            public int First;
            public int Second;
            public TwinsPair(int first, int second)
            {
                First = first;
                Second = second;
            }
        }
    }
}