using System;
using System.Linq;

namespace Practice.SimpleTasks
{
    public class T2
    {
        // CodeBlog #Task 912. В музее регистрируется в течение суток время прихода и ухода каждого посетителя.
        // Таким образом, за день получены N пар значений,
        // где первое значение в паре показывает время прихода посетителя и второе значение - время его ухода.
        // Требуется найти максимальное число посетителей, которые находились в музее одновременно

        public static void Task()
        {
            var records = (Enumerable.Range(1, 100)
                .Select(r => new TimeRecord())).ToList();

            int maxCount = 0;
            DateTime now = DateTime.Now;
            DateTime currentDate = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);

            foreach (var timeRecord in records)
            {
                Console.WriteLine(timeRecord.DateCame + " came");
                Console.WriteLine(timeRecord.DateGone + " gone");
            }
            
            for (; currentDate <= TimeRecord.CloseTime(); currentDate = currentDate.AddHours(1))
            {
                var count = 0;
                foreach (var record in records)
                {
                    if (record.InTimeRange(currentDate))
                        count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                }
            }

            Console.WriteLine(maxCount);
        }

    }

    public class TimeRecord
    {
        //Используется для обозначения времени закрытия музея
        private static readonly DateTime _closeTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
            21, 0, 0);
        
        //Используется для обозначения времени открытия музея
        private static readonly DateTime _openTime = new DateTime(_closeTime.Year, _closeTime.Month, _closeTime.Day,
            8, 0, 0);

        private static readonly Random _rnd = new Random();

        public static DateTime CloseTime()
        {
            return _closeTime;
        }

        public readonly DateTime DateCame;
        public readonly DateTime DateGone;

        public TimeRecord()
        {
            DateCame = _openTime.AddHours(_rnd.Next(0, _closeTime.Hour - _openTime.Hour));
            DateGone = _closeTime.AddHours(-_rnd.Next(0, _closeTime.Hour - DateCame.Hour));
        }

        public bool InTimeRange(DateTime date)
        {
            return date >= DateCame && date <= DateGone;
        }
    }
}