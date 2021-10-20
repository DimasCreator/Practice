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
            var answer = sequence.Where(s => s.Length == L).Min();
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дана последовательность непустых строк.
        /// Используя метод Aggregate, получить строку,
        /// состоящую из начальных символов всех строк исходной последовательности.
        /// </summary>
        public static void Task11()
        {
            List<string> sequence = new List<string>()
                {"DSACS", "DSSCS", "CMSKAMCKAS", "KCMSAK", "MSCK","CMMA","MVDK","KDS"};
            var answer = sequence.Aggregate("", (accum, next) => accum + next[0]);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Используя метод Aggregate, найти произведение последних цифр всех элементов последовательности.
        /// Чтобы избежать целочисленного переполнения, при вычислении произведения использовать вещественный числовой тип.
        /// </summary>
        public static void Task12()
        {
            IEnumerable<int> sequence = new List<int>() {-1, 2, 3, 4, 5};
            var answer = sequence.Aggregate(1.0, (accum, next) => accum * next);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дано целое число N (> 0).
        /// Используя методы Range и Sum, найти сумму 1 + (1/2) + ... + (1/N) (как вещественное число).
        /// </summary>
        public static void Task13()
        {
            int N = 3;
            var answer = Enumerable.Range(1, N).Sum(i => 1.0 / i);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Даны целые числа A и B (B > A). Используя методы Range и Average,
        /// найти среднее арифметическое квадратов всех целых чисел от A до B включительно:
        /// (A^2 + (A+1)^2 + ... + B^2)/(B − A + 1) (как вещественное число).
        /// </summary>
        public static void Task14()
        {
            int A = 1;
            int B = 3;
            var answer = Enumerable.Range(A, B).Average(i => i * i);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дано целое число N (0 ≤ N ≤ 15).
        /// Используя методы Range и Aggregate, найти факториал числа N:
        /// N! = 1·2·...·N при N ≥ 1; 0! = 1.
        /// Чтобы избежать целочисленного переполнения, при вычислении факториала использовать вещественный числовой тип.
        /// </summary>
        public static void Task15()
        {
            int N = 4;
            var answer = Enumerable.Range(1, N).Aggregate(1.0, (accum, next) => accum * next);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Извлечь из нее все положительные числа, сохранив их исходный порядок следования.
        /// </summary>
        public static void Task16()
        {
            List<int> sequence = new List<int>() {-1, -3, -6, 5, -4, -55, -4, 555, 1, -2, -5, -3, -6, 1, 2, 2, 4, 55, 6, 4};
            var answer = sequence.Where(i => i >= 0);
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Извлечь из нее все нечетные числа,
        /// сохранив их исходный порядок следования и удалив все вхождения повторяющихся элементов, кроме первых.
        /// </summary>
        public static void Task17()
        {
            List<int> sequence = new List<int>() {1, 4, 2, 5, 2, 6, 3, 5, 6, 8, 8, 6, 3, 2};
            var answer = sequence.Where(i => i % 2 == 0).Distinct();
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Извлечь из нее все четные отрицательные числа, поменяв порядок извлеченных чисел на обратный.
        /// </summary>
        public static void Task18()
        {
            List<int> sequence = new List<int>() {1, -4, 2, -5, -2, 6, -3, -5, 6, -8, -8, -6, -3, 2};
            var answer = sequence.Where(i => i < 0 && i % 2 == 0).Reverse();
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дана цифра D (целое однозначное число) и целочисленная последовательность A.
        /// Извлечь из A все различные положительные числа, оканчивающиеся цифрой D (в исходном порядке).
        /// При наличии повторяющихся элементов удалять все их вхождения, кроме последних.
        /// Указание. Последовательно применить методы Reverse, Distinct, Reverse.
        /// </summary>
        public static void Task19()
        {
            int D = 6;
            List<int> sequence = new List<int>() {6, -4, 2, 56, -5, -2, 6, -3, 66, 66, 56, -5, 6, -8, -8, -6, -3, 2};
            var answer = sequence.Where(i => i > 0 && i % 10 == D).Reverse().Distinct().Reverse();
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Извлечь из нее все положительные двузначные числа, отсортировав их по возрастанию.
        /// </summary>
        public static void Task20()
        {
            List<int> sequence = new List<int>() {6, -4, 2, 56, -5, -2, 6, -3, 66, 66, 56, -5, 6, -8, -8, -6, -3, 2};
            var answer = sequence.Where(i => i > 9 && i < 100).OrderBy(i=>i);
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дана строковая последовательность.
        /// Строки последовательности содержат только заглавные буквы латинского алфавита.
        /// Отсортировать последовательность по возрастанию длин строк,
        /// а строки одинаковой длины — в лексикографическом порядке по убыванию.
        /// </summary>
        public static void Task21()
        {
            List<string> sequence = new List<string>()
                {"A", "B", "C", "AA", "AB", "AC", "AAA", "AAB", "AAC"};
            var answer = sequence.OrderBy(s => s.Length).ThenByDescending(s => s);
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
        /// <summary>
        /// Дано целое число K (> 0) и строковая последовательность A.
        /// Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
        /// Извлечь из A все строки длины K, оканчивающиеся цифрой,
        /// отсортировав их в лексикографическом порядке по возрастанию.
        /// </summary>
        public static void Task22()
        {
            int K = 3;
            List<string> sequence = new List<string>()
                {"A3", "B2", "C", "AA3", "AB4", "AC", "AA1", "AA2", "A4C"};
            var answer = sequence.Where(s => s.Length == K && Char.IsNumber(s[^1])).OrderBy(s => s);
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
        /// <summary>
        /// Дано целое число K (> 0) и целочисленная последовательность A.
        /// Начиная с элемента A с порядковым номером K,
        /// извлечь из A все нечетные двузначные числа, отсортировав их по убыванию.
        /// </summary>
        public static void Task23()
        {
            int K = 4;
            List<int> sequence = new List<int>() {1, 2, 44, 53, -43, -54, 65, 76, -15};
            var answer = sequence.Skip(K - 1).Where(i => (i > -100 && i < -9 || i > 9 && i < 100) && i % 2 != 0)
                .OrderBy(i => i);
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дано целое число K (> 0) и строковая последовательность A.
        /// Из элементов A, предшествующих элементу с порядковым номером K,
        /// извлечь те строки, которые имеют нечетную длину и начинаются с заглавной латинской буквы,
        /// изменив порядок следования извлеченных строк на обратный.
        /// </summary>
        public static void Task24()
        {
            int K = 8;
            List<string> sequence = new List<string>()
                {"A3", "B2", "C", "AA3", "AB4", "AC", "aA1", "AA2", "A4C"};
            var answer = sequence.Take(K - 1).Where(s => s.Length % 2 != 0 && Char.IsUpper(s[0])).Reverse();
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
        /// <summary>
        /// Даны целые числа K1 и K2 и целочисленная последовательность A;
        /// N > K2 > K1 >= 1, где N — размер последовательности A.
        /// Найти сумму положительных элементов последовательности с порядковыми номерами от K1 до K2 включительно.
        /// </summary>
        public static void Task25()
        {
            int K1 = 2;
            int K2 = 7;
            List<int> sequence = new List<int>() {1, 1, -1, -1, 1, 1, -1, 1, 1};
            var answer = sequence.Skip(K1 - 1).Take(K2 - K1 + 1).Where(i => i > 0).Sum();
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Даны целые числа K1 и K2 и последовательность непустых строк A;
        /// N > K2 > K1 >= 1, где N — размер последовательности A.
        /// Найти среднее арифметическое длин всех элементов последовательности,
        /// кроме элементов с порядковыми номерами от K1 до K2 включительно, и вывести его как вещественное число.
        /// </summary>
        public static void Task26()
        {
            int K1 = 2;
            int K2 = 7;
            List<string> sequence = new List<string>()
                {"A3", "B2", "C", "AA3", "AB4", "AC", "AA1", "AA2", "A4C"};
            var answer = sequence.Take(K1 - 1).Concat(sequence.Skip(K2)).Average(s => s.Length);
            Console.WriteLine(answer);
        }
        /// <summary>
        /// Дано целое число D и целочисленная последовательность A.
        /// Начиная с первого элемента A, большего D, извлечь из A все нечетные положительные числа,
        /// поменяв порядок извлеченных чисел на обратный.
        /// </summary>
        public static void Task27()
        {
            int D = 45;
            List<int> sequence = new List<int>() {1, 2, 44, 53, -43, -54, 65, 76, -15};
            var answer = sequence.SkipWhile(i => i < D).Where(i => i > 0 && i % 2 != 0).Reverse();
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дано целое число L (> 0) и последовательность непустых строк A.
        /// Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
        /// Из элементов A, предшествующих первому элементу, длина которого превышает L,
        /// извлечь строки, оканчивающиеся буквой.
        /// Полученную последовательность отсортировать по убыванию длин строк,
        /// а строки одинаковой длины — в лексикографическом порядке по возрастанию.
        /// </summary>
        public static void Task28()
        {
            int L = 3;
            IEnumerable<string> sequence = new List<string>()
                {"KNKD4M", "MCKD23KDC", "9KCMDK3", "KAMK5A", "KVMK5K", "KC3", "MVK23", "DKM"};
            var answer = sequence.TakeWhile(s => s.Length != L).Where(s => Char.IsLetter(s[^1]))
                .OrderByDescending(s => s.Length).ThenBy(s => s);
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
        /// <summary>
        /// Даны целые числа D и K (K > 0) и целочисленная последовательность A.
        /// Найти теоретикомножественное объединение двух фрагментов A:
        /// первый содержит все элементы до первого элемента, большего D (не включая его),
        /// а второй — все элементы, начиная с элемента с порядковым номером K.
        /// Полученную последовательность (не содержащую одинаковых элементов) отсортировать по убыванию.
        /// </summary>
        public static void Task29()
        {
            int K = 5;
            int D = 7;
            IEnumerable<int> sequence = new List<int>() {4, 3, 6, 8, -12, 9, 4, -5, 6, -4, 6};
            var answer = sequence.TakeWhile(i => i < D).Union(sequence.Skip(K - 1)).OrderByDescending(i => i);
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дано целое число K (> 0) и целочисленная последовательность A.
        /// Найти теоретикомножественную разность двух фрагментов A:
        /// первый содержит все четные числа,
        /// а второй — все числа с порядковыми номерами, большими K.
        /// В полученной последовательности (не содержащей одинаковых элементов) поменять порядок элементов на обратный.
        /// </summary>
        public static void Task30()
        {
            int K = 6;
            IEnumerable<int> sequence = new List<int>() {4, 2, 2, 3, 6, 8, -12, 9, 4, -5, 6, -4, 6, 14, 14};
            var answer = sequence.Where(i => i % 2 == 0).Except(sequence.Skip(K)).Reverse();
            foreach (var num in answer)
            {
                Console.Write(num + " ");
            }
        }
        /// <summary>
        /// Дано целое число K (> 0) и последовательность непустых строк A.
        /// Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
        /// Найти теоретикомножественное пересечение двух фрагментов A:
        /// первый содержит K начальных элементов, а второй — все элементы, расположенные после последнего элемента, оканчивающегося цифрой.
        /// Полученную последовательность (не содержащую одинаковых элементов) отсортировать по возрастанию длин строк,
        /// а строки одинаковой длины — в лексикографическом порядке по возрастанию.
        /// </summary>
        public static void Task31()
        {
            int K = 5;
            IEnumerable<string> sequence = new List<string>()
                {"KNKD4M", "MCKD23KDC", "9KCMDK3", "KAMK5A", "KVMK5K", "KC3", "MVK23", "DKM"};
            var answer = sequence.Take(K).Intersect(sequence.Reverse().SkipWhile(s => Char.IsNumber(s[^1])))
                .OrderBy(s => s.Length).ThenBy(s => s);
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
        /// <summary>
        /// Дана последовательность непустых строк A.
        /// Получить последовательность символов, каждый элемент которой является начальным символом соответствующей строки из A.
        /// Порядок символов должен быть обратным по отношению к порядку элементов исходной последовательности.
        /// </summary>
        public static void Task32()
        {
            IEnumerable<string> sequence = new List<string>()
                {"KNKD4M", "MCKD23KDC", "9KCMDK3", "KAMK5A", "KVMK5K", "KC3", "MVK23", "DKM"};
            var answer = sequence.Select(s => s[0]).Reverse();
            foreach (var c in answer)
            {
                Console.WriteLine(c);
            }
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Обрабатывая только положительные числа, получить последовательность их последних цифр и
        /// удалить в полученной последовательности все вхождения одинаковых цифр, кроме первого. (Первого чего? Вхождения? или числа?)
        /// Порядок полученных цифр должен соответствовать порядку исходных чисел.
        /// </summary>
        public static void Task33()
        {
            IEnumerable<int> sequence = new List<int>() {4, 2, 2, 3, 6, 8, -12, 9, 4, -5, 6, -4, 6, 14, 14};
            var answer = sequence.Where(i => i > 0).Select(i => i % 10).Distinct();
            foreach (var number in answer)
            {
                Console.Write(number + " ");
            }
        }
        /// <summary>
        /// Дана последовательность положительных целых чисел.
        /// Обрабатывая только нечетные числа, получить последовательность их строковых представлений и
        /// отсортировать ее в лексикографическом порядке по возрастанию.
        /// </summary>
        public static void Task34()
        {
            IEnumerable<int> sequence = new List<int>() {4, 2, 2, 3, 6, 8, 12, 9, 4, 5, 6, 4, 6, 14, 14, 15, 17, 13};
            var answer = sequence.Where(i => i % 2 != 0).Select(i => i.ToString()).OrderBy(s => s);
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
        /// <summary>
        /// Дана целочисленная последовательность.
        /// Получить последовательность чисел, каждый элемент которой равен
        /// произведению соответствующего элемента исходной последовательности на его порядковый номер (1, 2, ...).
        /// В полученной последовательности удалить все элементы, не являющиеся двузначными,
        /// и поменять порядок оставшихся элементов на обратный.
        /// </summary>
        public static void Task35()
        {
            IEnumerable<int> sequence = new List<int>() {4, 2, 2, 3, 6, 8, 12, 9, 4, 5, 6, 4, 6, 14, 14, 15, 17, 13};
            var answer = sequence.Select((number, index) => number * index).Where(i => i < 9 || i > 99).Reverse();
            foreach (var number in answer)
            {
                Console.Write(number + " ");
            }
        }
        /// <summary>
        /// Дана последовательность непустых строк.
        /// Получить последовательность символов, которая определяется следующим образом:
        /// если соответствующая строка исходной последовательности имеет нечетную длину,
        /// то в качестве символа берется первый символ этой строки;
        /// в противном случае берется последний символ строки.
        /// Отсортировать полученные символы по убыванию их кодов.
        /// </summary>
        public static void Task36()
        {
            IEnumerable<string> sequence = new List<string>()
                {"kscmkds", "kmdksv", "utnrb", "kenffjpb", "pekjv", "njgrbbd", "teyduv"};
            var answer = sequence.Select(s => s.Length % 2 != 0 ? s[0] : s[^1]).OrderByDescending(c => c);
            foreach (var c in answer)
            {
                Console.Write(c + " ");
            }
        }
        /// <summary>
        /// Дана строковая последовательность A.
        /// Строки последовательности содержат только заглавные буквы латинского алфавита.
        /// Получить новую последовательность строк, элементы которой определяются по соответствующим элементам A следующим образом:
        /// пустые строки в новую последовательность не включаются,
        /// а к непустым приписывается порядковый номер данной строки в исходной последовательности
        /// (например, если пятый элемент A имеет вид «ABC», то в полученной последовательности он будет иметь вид «ABC5»).
        /// При нумерации должны учитываться и пустые строки последовательности A.
        /// Отсортировать полученную последовательность в лексикографическом порядке по возрастанию.
        /// </summary>
        public static void Task37()
        {
            IEnumerable<string> sequence = new List<string>()
                {"VFKSKFS", "OEMDF", "", "VFLDS", "VLSFDF", "", "MBKGDLG", "LEPCM", "DMSL"};
            var answer = sequence.Select((str, index) => str.Length != 0 ? str + index : str).Where(s => s.Length != 0)
                .OrderBy(s => s);
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
        /// <summary>
        /// Дана целочисленная последовательность A.
        /// Получить новую последовательность чисел,
        /// элементы которой определяются по соответствующим элементам последовательности A следующим образом:
        /// если порядковый номер элемента A делится на 3 (3, 6, ...), то этот элемент в новую последовательность не включается;
        /// если остаток от деления порядкового номера на 3 равен 1 (1, 4, ...), то в
        /// новую последовательность добавляется удвоенное значение этого элемента;
        /// в противном случае (для элементов A с номерами 2, 5, ...) элемент добавляется в новую последовательность без изменений.
        /// В полученной последовательности сохранить исходный порядок следования элементов.
        /// </summary>
        public static void Task38()
        {
            IEnumerable<int> sequence = new List<int>() {1, 4, 5, 2, 3, 4, 2, 1, 5, 6, 8, 3, 5, 4, 6, 2, 4, 6, 7};
            var answer =
                sequence.Select((number, index) => index % 3 == 0 ? number : index % 3 == 1 ? number * 2 : number)
                    .Where((_, index) => index % 3 != 0);
            foreach (var number in answer)
            {
                Console.Write(number + " ");
            }
        }
        /// <summary>
        /// Дана строковая последовательность A.
        /// Получить последовательность цифровых символов,
        /// входящих в строки последовательности A (символы могут повторяться).
        /// Порядок символов должен соответствовать порядку строк A и порядку следования символов в каждой строке.
        /// Указание. Использовать метод SelectMany с учетом того, что строка может интерпретироваться как последовательность символов.
        /// </summary>
        public static void Task39()
        {
            IEnumerable<string> sequence = new List<string>()
                {"kscmkd42s", "kmdks5v", "utn1rb", "kenffjpb", "pe89kjv", "njgrbb5d", "teydu9v"};
            var answer = sequence.SelectMany(s => s.ToCharArray(), (_, c) => c).Where(Char.IsNumber);
            foreach (var number in answer)
            {
                Console.Write(number + " ");
            }
        }
        /// <summary>
        /// Дано число K (> 0) и строковая последовательность A.
        /// Получить последовательность символов, содержащую символы всех строк из A,
        /// имеющих длину, большую или равную K (символы могут повторяться).
        /// В полученной последовательности поменять порядок элементов на обратный.
        /// </summary>
        public static void Task40()
        {
            int K = 5;
            IEnumerable<string> sequence = new List<string>()
                {"kscmkd42s", "kmdks5v", "dsaf", "kenffjpb", "dls", "njgrbb5d", "teydu9v"};
            var answer = sequence.Where(s => s.Length >= K).SelectMany(str => str.ToCharArray(), (_, c) => c);
            foreach (var c in answer)
            {
                Console.Write(c + " ");
            }
        }
        /// <summary>
        /// Дано целое число K (> 0) и строковая последовательность A.
        /// Каждый элемент последовательности представляет собой несколько слов из заглавных латинских букв, разделенных символами «.» (точка).
        /// Получить последовательность строк, содержащую все слова длины K из элементов A в лексикографическом порядке по возрастанию (слова могут повторяться).
        /// </summary>
        public static void Task41()
        {
            int K = 4;
            IEnumerable<string> sequence = new List<string>()
                {"DS.FSV.DSFD.DSA.EWQR.CVCZ", "DSA.CXZ.FDA.EW.G", "D.S.F.C", "CDA.SDA.W.REWF"};
            var answer = sequence.Select(s => s.Split('.')).SelectMany(s => s).Where(s => s.Length == K)
                .OrderBy(s => s);
            foreach (var str in answer)
            {
                Console.Write(str + " ");
            }
        }
    }
}