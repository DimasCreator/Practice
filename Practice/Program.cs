using System;
using System.Linq;
using System.Collections.Generic;
using Practice.Tasks;

Console.WriteLine("Hello from Practice");

Console.WriteLine(T6.Task("{[<>]}"));//True
Console.WriteLine(T6.Task("({}[])"));//False
Console.WriteLine(T6.Task("({[})]"));//False
Console.WriteLine(T6.Task("({[]})"));//True
Console.WriteLine(T6.Task("({[})"));//False

Console.WriteLine(T6.TaskStack("{[<>]}"));//True
Console.WriteLine(T6.TaskStack("({}[])"));//True
Console.WriteLine(T6.TaskStack("({[})]"));//False
Console.WriteLine(T6.TaskStack("({[]})"));//True
Console.WriteLine(T6.TaskStack("({[})"));//false
