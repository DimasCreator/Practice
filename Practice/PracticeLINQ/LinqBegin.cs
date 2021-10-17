using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice.PracticeLINQ
{
    public static class LinqBegin
    {
        /// <summary>
        /// Дана целочисленная последовательность, содержащая как положительные,
        /// так и отрицательные числа. Вывести ее первый положительный элемент и последний отрицательный элемент.
        /// </summary>
        public static void Task1()
        {
            List<int> sequence = new List<int>() {-1, -3, -6, -4, -4, 1, -2, -5, -3, -6, 1, 2, 2, 4, 55, 6, 4};
            var firstPositive = sequence.FirstOrDefault(i => i >= 0);
            var lastNegative = sequence.Last(i => i < 0);
            Console.WriteLine(firstPositive + " " + lastNegative);
        }
        /// <summary>
        /// Дана цифра D (однозначное целое число) и целочисленная последовательность A.
        /// Вывести первый положительный элемент последовательности A,
        /// оканчивающийся цифрой D. Если требуемых элементов в последовательности A нет, то вывести 0.
        /// </summary>
        public static void Task2()
        {
            int D = 5;
            List<int> sequence = new List<int>() {-1, -3, -6, 5, -4, -55, -4, 555, 1, -2, -5, -3, -6, 1, 2, 2, 4, 55, 6, 4};
            var answer = sequence.FirstOrDefault(i => i > 0 && i % 10 == D);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дано целое число L (> 0) и строковая последовательность A.
        /// Вывести последнюю строку из A, начинающуюся с цифры и имеющую длину L.
        /// Если требуемых строк в последовательности A нет, то вывести строку «Not found».
        /// Указание. Для обработки ситуации, связанной с отсутствием требуемых строк, использовать операцию ??.
        /// </summary>
        public static void Task3()
        {
            int L = 7;
            List<string> sequence = new List<string>()
                {"danvsa", "", "kkdamkdmfa", "oqfe", "35mcsamd", null, "efsdds", "35mdkam", "dlsa", "35mdkamdas"};
            var answer = sequence.FirstOrDefault(s => s?.Length == L && char.IsNumber(s, 0)) ?? "Not found";
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дан символ С и строковая последовательность A.
        /// Если A содержит единственный элемент, оканчивающийся символом C,
        /// то вывести этот элемент; если требуемых строк в A нет, то вывести пустую строку;
        /// если требуемых строк больше одной, то вывести строку «Error».
        /// Указание. Использовать try-блок для перехвата возможного исключения.
        /// </summary>
        public static void Task4()
        {
            char C = 'c';
            List<string> sequence = new List<string>()
                {"caslcs", "", "dsadc", "dsadsafc", "kmkfd", "kfkds", null, "efsdds", "35mdkam", "dlsa", "35mdkamdas"};
            try
            {
                var answer = sequence.Single(s => !string.IsNullOrEmpty(s) && s[^1] == C);
                Console.WriteLine(answer);
            }
            catch (InvalidOperationException e)
            {
                if(e.Message == "Sequence contains no matching element")
                    Console.WriteLine("");
                else
                    Console.WriteLine("Error");
            }
        }
        /// <summary>
        /// Дан символ С и строковая последовательность A.
        /// Найти количество элементов A, которые содержат более одного символа
        /// и при этом начинаются и оканчиваются символом C.
        /// </summary>
        public static void Task5()
        {
            char C = 'c';
            List<string> sequence = new List<string>()
                {"caslcs", "", "c", "cdsadc", "dsadsafc", "ckmkfdc", "kfkds", null, "cefsddsc", "35mdkam", "dlsa", "35mdkamdas"};
            var answer = sequence.Count(s => s?.Length > 1 && s[0] == C && s[^1] == C);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дана строковая последовательность.
        /// Найти сумму длин всех строк, входящих в данную последовательность.
        /// </summary>
        public static void Task6()
        {
            List<string> sequence = new List<string>()
                {"ld", "12d", " ", "ds"};
            var answer = sequence.Sum(s => s?.Length);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Найти количество ее отрицательных элементов, а также их сумму.
        /// Если отрицательные элементы отсутствуют, то дважды вывести 0.
        /// </summary>
        public static void Task7()
        {
            List<int> sequence = new List<int>() {-1, -2, -3, -4, -5, 1, 2, 3, 4, 5};
            var answer = sequence.Where(i => i < 0).Sum();
            Console.WriteLine(answer);
        }
    }
}