using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice.PracticeLINQ
{
    public static class PracticeClass
    {
        class Phone
        {
            public string Name { get; set; }
            public string Company { get; set; }
        }

        public static void Task()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="iPhone 5", Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4", Company="LG" }
            };
 
            var phoneGroups = phones.GroupBy(p => p.Company)
                .Select(g => new
                { 
                    Name = g.Key, 
                    Count = g.Count(), 
                    Phones = g.Select(p =>p) 
                });
        }
    }
}