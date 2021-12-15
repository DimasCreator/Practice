using System;
using System.Linq;
using System.Collections.Generic;
using Practice.PracticeLINQ;

Console.WriteLine("Hello from Practice");
Document[] documents =
{
    new Document {Id = 1, Text = "Hello world!"},
    new Document {Id = 2, Text = "World, world, world... Just words..."},
    new Document {Id = 3, Text = "Words — power"},
    new Document {Id = 4, Text = ""}
};

foreach (var s in UlearnLinq.Task9(documents))
{
    Console.WriteLine(s);
}