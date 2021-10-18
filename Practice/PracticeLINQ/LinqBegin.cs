using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice.PracticeLINQ
{
    /// <summary>
    /// Класс практики Linq
    /// Решение всех задач нацелено на наименьшее количество проходов по последовательности
    /// </summary>
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
        ///ПОТЕСТИТЬ НА СКОРОСТЬ РАЗЛИЧНЫЕ ВАРИАНТЫ
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Найти количество ее отрицательных элементов, а также их сумму.
        /// Если отрицательные элементы отсутствуют, то дважды вывести 0.
        /// </summary>
        public static void Task7()
        {
            List<int> sequence = new List<int>() {-1, -2, -3, -4, -5, 1, 2, 3, 4, 5};
            var answer = sequence.Aggregate((Count: 0, Sum: 0),
                (accum, value) => value < 0 ? (Count: accum.Count + 1, Sum: accum.Sum + value) : accum);
            Console.WriteLine(answer.Count + " " + answer.Sum);
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Найти количество ее положительных двузначных элементов,
        /// а также их среднее арифметическое (как вещественное число).
        /// Если требуемые элементы отсутствуют, то дважды вывести 0 (первый раз как целое, второй — как вещественное).
        /// </summary>
        public static void Task8()
        {
            List<int> sequence = new List<int>() {-1, -2, -31, -40, -5, 1, 2, 23, 44, 5543, 213};
            var answer = sequence.Aggregate((Count: 0, Sum: 0),
                (accum, value) => value > 9 && value < 100 ? 
                    (Count: accum.Count + 1, Sum: accum.Sum + value) : accum);
            Console.WriteLine(answer.Count + " " + (double)answer.Sum / answer.Count);
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Вывести ее минимальный положительный элемент или число 0,
        /// если последовательность не содержит положительных элементов.
        /// </summary>
        public static void Task9()
        {
            IEnumerable<int> sequence = new List<int>() {-1, -2, -31, -40, -5, 2, 2, 23, 44, 5543, 213};
            var answer = sequence.Aggregate((Answer: 0, Min: int.MaxValue),
                (accum, next) => next > 0 && next < accum.Min ? (Answer: next, Min: next) : accum);
            Console.WriteLine(answer.Answer);
        }
        /// <summary>
        /// Дано целое число L (> 0) и строковая последовательность A.
        /// Строки последовательности A содержат только заглавные буквы латинского алфавита.
        /// Среди всех строк из A, имеющих длину L, найти наибольшую (в смысле лексикографического порядка).
        /// Вывести эту строку или пустую строку, если последовательность не содержит строк длины L.
        /// </summary>
        public static void Task10()
        {
            int L = 5;
            List<string> sequence = new List<string>()
                {"DSACS", "DSSCS", "CMSKAMCKAS", "KCMSAK", "MSCK","CMMA","MVDK","KDS"};
            var answer = sequence.OrderBy(s => s).FirstOrDefault(s => s.Length == L);
            Console.WriteLine(answer);
        }
    }
}