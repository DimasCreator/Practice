using System;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.Threads
{
    public class PracticeClass
    {
        public static void Task()
        {
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine(i + "  " + Thread.CurrentThread.IsAlive);
            }
        }
    }
}