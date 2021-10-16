using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.Threads
{
    public class PracticeClass
    {
        public static void Task()
        {
             
        }

        //Таймер
        //public static void Task()
        //{
        //    int num = 0;
        //    // устанавливаем метод обратного вызова
        //    TimerCallback tm = Count;
        //    // создаем таймер

        //    Timer timer = new Timer(tm, num, 0, 2000);

        //    Console.ReadLine();
        //}
        //public static void Count(object obj)
        //{
        //    int x = (int)obj;
        //    for (int i = 1; i < 9; i++, x++)
        //    {
        //        Console.WriteLine($"{x * i}");
        //    }
        //}


        //Работа с потоками и их синхронизация с помощью lock
        //static object locker = new object();
        //public static void Task()
        //{
        //static int x = 0;
        //    var watch = Stopwatch.StartNew();
        //    List<Thread> threads = new List<Thread>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Thread myThread = new Thread(Count);
        //        myThread.Name = "Поток " + i.ToString();
        //        threads.Add(myThread);
        //    }

        //    foreach(var thread in threads)
        //    {
        //        thread.Start();
        //    }

        //    for(int i = 0; i < threads.Count; i++)
        //    {
        //        if (threads[i].IsAlive)
        //        {
        //            i = -1;
        //            continue;
        //        }
        //    }
        //    Console.WriteLine("Конец" + watch.ElapsedMilliseconds);
        //    Console.ReadLine();
        //}
        //public static void Count()
        //{
        //    #region Блок кода идущий параллельно
        //    var watch = Stopwatch.StartNew();

        //    Console.WriteLine($"{Thread.CurrentThread.Name} Запущен");
        //    for(int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name} вычисление");
        //        Thread.Sleep(100);
        //    }

        //    Console.WriteLine($"{Thread.CurrentThread.Name} цикл завершен");

        //    Console.WriteLine($"{Thread.CurrentThread.Name} вычисления:  {watch.ElapsedMilliseconds}");
        //    #endregion

        //    watch = Stopwatch.StartNew();
        //    #region блок кода идущий последовательно
        //    lock (locker)
        //    {
        //        x = 1;
        //        for (int i = 1; i < 9; i++)
        //        {
        //            Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
        //            x++;
        //            Thread.Sleep(100);
        //        }
        //    }
        //    #endregion
        //    Console.WriteLine($"{Thread.CurrentThread.Name} конец: {watch.ElapsedMilliseconds} ");
        //}
    }
}