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
            public int DurationOfClassesPerMounth;

            public Client()
            {
                Id = _idCount++;
                Year = _rnd.Next(2018, 2022);
                Month = _rnd.Next(1, 13);
                DurationOfClassesPerMounth = _rnd.Next(30, 60);
            }

            public bool DataLaterThan(Client client)
            {
                if (client.Year < Year) return false;
                if (client.Month < Month) return false;
                return true;
            }

            public DateTime GetData()
            {
                return new DateTime(Year, Month, 1);
            }

            public static IEnumerable<Client> GetClientEnumerable(int count)//TODO: Подкоректировать метод
            {
                LinkedList<Client> sequence = new LinkedList<Client>();
                for (var i = 0; i < count; i++)
                {
                    sequence.AddLast(new Client());
                }
                
                return sequence;
            }
            
            
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Найти элемент последовательности с минимальной продолжительностью занятий.
        /// Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке).
        /// Если имеется несколько элементов с минимальной продолжительностью, то вывести данные того из них,
        /// который является последним в исходной последовательности.
        /// </summary>
        public static void Task1()// сделал за один проход. Проверить со  Skip и без
        {
            IEnumerable<Client> sequence = Client.GetClientEnumerable(10);
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
            }
            var answer = sequence.Skip(1).Aggregate(sequence.First(),
                (min, next) => next.DurationOfClassesPerMounth <= min.DurationOfClassesPerMounth ? next : min);
            Console.WriteLine("Result");
            Console.WriteLine("Id: " + answer.Id + "\t" + "Month: " + answer.Month + "\t" + "Year: " + answer.Year +
                              "\t" + "Duration:" + answer.DurationOfClassesPerMounth);
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Найти элемент последовательности с максимальной продолжительностью занятий.
        /// Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в указанном порядке на той же строке).
        /// Если имеется несколько элементов с максимальной продолжительностью, то вывести данные, соответствующие самой поздней дате.
        /// </summary>
        public static void Task2()//TODO: Определится со Skip(1)
        {
            IEnumerable<Client> sequence = Client.GetClientEnumerable(10);
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
            }

            var answer = sequence.Aggregate(sequence.First(),
                (max, next) => next.DurationOfClassesPerMounth > max.DurationOfClassesPerMounth ? next :
                    next.DurationOfClassesPerMounth == max.DurationOfClassesPerMounth && next.DataLaterThan(max) ? next : max);
            Console.WriteLine("Result");
            Console.WriteLine("Id: " + answer.Id + "\t" + "Month: " + answer.Month + "\t" + "Year: " + answer.Year +
                              "\t" + "Duration:" + answer.DurationOfClassesPerMounth);
        }
        
        /// <summary>
        /// Исходная последовательность содержит сведения о клиентах фитнес-центра (Класс Client).
        /// Определить год, в котором суммарная продолжительность занятий всех клиентов была наибольшей,
        /// и вывести этот год и наибольшую суммарную продолжительность. Если таких годов было несколько, то вывести наименьший из них.
        /// </summary>
        public static void Task3()//TODO: подумать над Skip(1)
        {
            IEnumerable<Client> sequence = Client.GetClientEnumerable(10);
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
            }

            var yearGroups = sequence.GroupBy(c => c.Year)
                .Select(g => new {Ds = g.Sum(c => c.DurationOfClassesPerMounth), Y = g.Key});
            var answer = yearGroups.Skip(1).Aggregate(yearGroups.First(),
                (acc, next) => next.Ds > acc.Ds ? next : next.Ds == acc.Ds && next.Y < acc.Y ? next : acc);
                
            foreach (var g in sequence.GroupBy(c => c.Year))
            {
                Console.WriteLine("Год: " + g.Key);
                Console.WriteLine( "Продолжительность:  " + g.Sum(c=>c.DurationOfClassesPerMounth));
                foreach (var c in g)
                {
                    Console.Write(c.DurationOfClassesPerMounth + "   "); 
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Result");
            Console.WriteLine(answer.Y + "   " + answer.Ds);
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
            IEnumerable<Client> sequence = Client.GetClientEnumerable(10).ToArray();
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
            }
            DateTime now = DateTime.Now;
            var answer = sequence.Select(c => new
            {
                Id = c.Id,
                SumDuration = c.DurationOfClassesPerMounth * (now - new DateTime(c.Year, c.Month, 1)).Days / 30
            }).OrderBy(o => o.SumDuration).ThenBy(o => o.Id);
            foreach (var item in answer)
            {
                Console.WriteLine(item.Id + "   " + item.SumDuration);
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
            IEnumerable<Client> sequence = Client.GetClientEnumerable(10).ToArray();
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
            }
            DateTime now = DateTime.Now;
            var answer = sequence.Select(c => new
            {
                Id = c.Id,
                SumDuration = (now - new DateTime(c.Year, c.Month, 1)).Days / 30
            }).OrderBy(o => o.SumDuration).ThenBy(o => o.Id);
            foreach (var item in answer)
            {
                Console.WriteLine(item.Id + "   " + item.SumDuration);
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
        public static void Task6()//TODO: Доделать
        {
            IEnumerable<Client> sequence = Client.GetClientEnumerable(5).ToArray();
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
            }

            var answer = sequence.GroupBy(c => c.Month);
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
        public static void Task7()//TODO: Сделать
        {
            IEnumerable<Client> sequence = Client.GetClientEnumerable(5).ToArray();
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
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
            IEnumerable<Client> sequence = Client.GetClientEnumerable(10).ToArray();
            foreach (var client in sequence)
            {
                Console.WriteLine("Id: " + client.Id + "\t" + "Month: " + client.Month + "\t" + "Year: " + client.Year +
                                  "\t" + "Duration:" + client.DurationOfClassesPerMounth);
            }

            var answer = sequence.Aggregate(sequence.First(),
                (max, next) => next.DurationOfClassesPerMounth > max.DurationOfClassesPerMounth ? next :
                    next.DurationOfClassesPerMounth == max.DurationOfClassesPerMounth ? next.GetData() < max.GetData()
                        ?
                        next
                        : max : max);
            Console.WriteLine("Answer");
            Console.WriteLine("Id: " + answer.Id + "\t" + "Month: " + answer.Month + "\t" + "Year: " + answer.Year +
                              "\t" + "Duration:" + answer.DurationOfClassesPerMounth);
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