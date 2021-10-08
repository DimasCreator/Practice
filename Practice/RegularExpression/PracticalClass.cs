using System;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Practice.RegularExpression
{
    public class PracticalClass
    {
        public static void Task()
        {
            string s = "Бык тупогуб, тупогубенький бычок, губотупенький у быка губа бела была тупа";
            Regex regex = new Regex(@"(\w*)туп(\w*)");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }

            s = "мир мор мар мер мср";
            regex = new Regex(@"м.р");
            matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }

            s = "9-957-432-1920";
            regex = new Regex(@"\d{1}-\d{3}-\d{3}-\d{4}");
            Console.WriteLine(regex.Matches(s)[0]);
        }
    }
}