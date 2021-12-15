using System;

namespace Practice.ProjectEulerTasks
{
    public static class T3
    {   
        /// <summary>TODO: Сделать
        /// Простыми множителями 13195 являются 5, 7, 13 и 29.
        /// Какой самый большой простой множитель числа 600851475143?
        /// </summary>
        public static void Task()
        {
            var l = 600851475143;
            var div = (int) Math.Sqrt(600851475143);
            while (div > 1)
            {
                if (l % div == 0 && IsPrime(div))
                {
                    Console.WriteLine(div);
                    return;
                }
                div--;
            }
        }

        private static bool IsPrime(int num)
        {
            double sqrt = Math.Sqrt(num);
            for (int i = 2; i <= sqrt; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}