using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.SimpleNumericAlgorithms
{
    public static class NumericClass
    {
        /// <summary>
        /// Calculates the factorial of a number
        /// </summary>
        /// <param name="number">Calculated number</param>
        /// <returns>Fuctorial</returns>
        public static int Factorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            return number * Factorial(--number);
        }

        /// <summary>
        /// Calculates a number from the Fibonacci sequence
        /// </summary>
        /// <param name="number">Sequence number</param>
        /// <returns>Fibonacci sequence number "number"</returns>
        public static int Fibonacci(int number)
        {
            return Fibonacci(0, 1, 2, number);
        }
        private static int Fibonacci(int first, int second, int current, int number)
        {
            if (current >= number)
            {
                return second;
            }
            return Fibonacci(second, first + second, ++current, number);
        }

        /// <summary>
        /// Greatest common divisor
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second Number</param>
        /// <returns>Greatest common divisor</returns>
        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }

        /// <summary>
        /// Least common multiple
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Least common multiple</returns>
        public static int LCM(int a, int b)
        {
            return a / GCD(a, b) * b;
        }
    }
}
