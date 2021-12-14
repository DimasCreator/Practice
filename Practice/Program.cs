using System;
using System.Linq;
using System.Collections.Generic;
using Practice.PracticeLINQ;

Console.WriteLine("Hello from Practice");


var vocabulary = UlearnLinq.Task5(
    "Hello, hello, hello, how low",
    "",
    "With the lights out, it's less dangerous",
    "Here we are now; entertain us",
    "I feel stupid and contagious",
    "Here we are now; entertain us",
    "A mulatto, an albino, a mosquito, my libido...",
    "Yeah, hey"
);
foreach (var word in vocabulary)
    Console.WriteLine(word);