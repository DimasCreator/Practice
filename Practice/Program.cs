using System;
using Practice.Threads;
using System.Threading;
using System.Threading.Tasks;
Console.WriteLine("Hello from Practice");

Task task = new Task(PracticeClass.Task);

for (int i = 0; i < 10000; i++)
{
    Thread.Sleep(100);
    Console.WriteLine(Thread.CurrentThread.Priority);
    Console.WriteLine(i);
}