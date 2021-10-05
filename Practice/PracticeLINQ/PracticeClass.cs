using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice.PracticeLINQ
{
    public static class PracticeClass
    {
        public static void Task()
        {
            var scores = new[] { 97, 92, 81, 60 };

            // Define the query expression.
            var scoreQuery = scores.Where(s => s > 80).Select(s => s + 100);

            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }
    }
}