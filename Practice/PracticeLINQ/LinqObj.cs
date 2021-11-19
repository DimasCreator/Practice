using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice.PracticeLINQ
{
    public static class LinqObj
    {
        private class Client
        {
            private static int _idCount = 1;
            private static readonly Random _rnd = new Random();
            
            public int Id;
            public int Year;
            public int Month;
            public int DurationOfClasses;

            public Client()
            {
                Id = _idCount++;
                Year = _rnd.Next(1990, 2022);
                Month = _rnd.Next(1, 13);
                DurationOfClasses = _rnd.Next(1, 10);
            }
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Найти элемент последовательности с минимальной продолжительностью занятий.
        /// Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке).
        /// Если имеется несколько элементов с минимальной продолжительностью, то вывести данные того из них,
        /// который является последним в исходной последовательности.
        /// </summary>
        public static void Task1() // TODO: попробовать сделать за один проход вообще рили это?
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClasses);
            }
            var minDuration = sequence.Min(c => c.DurationOfClasses);
            var answer = sequence.Reverse().First(c => c.DurationOfClasses == minDuration);
            Console.WriteLine("Result");
            Console.WriteLine("Id: " + answer.Id + "\t" + "Month: " + answer.Month + "\t" + "Year: " + answer.Year +
                              "\t" + "Duration:" + answer.DurationOfClasses);
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Найти элемент последовательности с максимальной продолжительностью занятий.
        /// Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке).
        /// Если имеется несколько элементов с максимальной продолжительностью, то вывести данные, соответствующие самой поздней дате.
        /// </summary>
        public static void Task2()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClasses);
            }
            
            var answer = sequence.OrderByDescending(c => c.DurationOfClasses).ThenBy(c => c.Year).First();
            
            Console.WriteLine("Result");
            Console.WriteLine("Id: " + answer.Id + "\t" + "Month: " + answer.Month + "\t" + "Year: " + answer.Year +
                              "\t" + "Duration:" + answer.DurationOfClasses);
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Определить год, в котором суммарная продолжительность занятий всех клиентов была наибольшей,
        /// и вывести этот год и наибольшую суммарную продолжительность. Если таких годов было несколько, то вывести наименьший из них.
        /// </summary>
        public static void Task3()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Для каждого клиента, присутствующего в исходных данных, определить суммарную продолжительность занятий в течение всех лет
        /// (вначале выводить суммарную продолжительность, затем код клиента).
        /// Сведения о каждом клиенте выводить на новой строке и упорядочивать по убыванию суммарной продолжительности,
        /// а при их равенстве — по возрастанию кода клиента.
        /// </summary>
        public static void Task4()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }

        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Для каждого клиента, присутствующего в исходных данных, определить общее количество месяцев,
        /// в течение которых он посещал занятия (вначале выводить количество месяцев, затем код клиента).
        /// Сведения о каждом клиенте выводить на новой строке и упорядочивать по возрастанию количества месяцев,
        /// а при их равенстве — по возрастанию кода клиента.
        /// </summary>
        public static void Task5()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Для каждого месяца определить суммарную продолжительность занятий всех клиентов за все годы
        /// (вначале выводить суммарную продолжительность, затем номер месяца).
        /// Если данные о некотором месяце отсутствуют, то для этого месяца вывести 0.
        /// Сведения о каждом месяце выводить на новой строке и упорядочивать по убыванию суммарной продолжительности,
        /// продолжительности — по возрастанию номера месяца.
        /// </summary>
        public static void Task6()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Для каждого года, в котором клиент с кодом K посещал центр, определить месяц,
        /// в котором продолжительность занятий данного клиента была наибольшей для данного года
        /// (если таких месяцев несколько, то выбирать месяц с наименьшим номером).
        /// Сведения о каждом годе выводить на новой строке в следующем порядке:
        /// год, номер месяца, продолжительность занятий в этом месяце.
        /// Упорядочивать сведения по убыванию номера года. Если данные о клиенте с кодом K отсутствуют,
        /// то записать в результирующий файл строку «Нет данных».
        /// </summary>
        public static void Task7()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Найти элемент последовательности с максимальной продолжительностью занятий.
        /// Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке).
        /// Если имеется несколько элементов с максимальной продолжительностью, то вывести данные, соответствующие самой поздней дате.
        /// </summary>
        public static void Task8()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Найти элемент последовательности с максимальной продолжительностью занятий.
        /// Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке).
        /// Если имеется несколько элементов с максимальной продолжительностью, то вывести данные, соответствующие самой поздней дате.
        /// </summary>
        public static void Task9()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Найти элемент последовательности с максимальной продолжительностью занятий.
        /// Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке).
        /// Если имеется несколько элементов с максимальной продолжительностью, то вывести данные, соответствующие самой поздней дате.
        /// </summary>
        public static void Task10()
        {
            IEnumerable<Client> sequence = new[]
                {new Client(), new Client(), new Client(), new Client(), new Client(), new Client(), new Client()};
            int id = 1;
            foreach (var client in sequence)
            {
                client.Id = id++;
            }
        }
    }
}