using Project_Anglia.Data;
using System.Collections.Generic;
using static System.Console;

namespace Project_Anglia
{
    class Program
    {
        public static List<Living> LivingPeople { get; set; }
        public static List<Dead> DeadPeople { get; set; }
        public static List<Family> Families { get; set; }

        static List<Living> Bakfis;

        public static int Year { get; protected set; }

        static void Main(string[] args)
        {
            Init();
            for (int i = 0; i < 1000; i++)
                PassYear();

            WriteLine("FINISHING SIMULATION");
            ReadKey();
        }

        static void Init()
        {
            Year = 0;
            WriteLine("STARTING SIMULATION:");
            LivingPeople = new List<Living>();
            DeadPeople = new List<Dead>();
            Families = new List<Family>();
            Bakfis = new List<Living>();
            for (int i = 0; i < 500; i++)
            {
                LivingPeople.Add(new Living());
            }
        }

        static void PassYear()
        {
            Year++;
            WriteLine($"Year {Year}");
            WriteLine($"Living: {LivingPeople.Count}");
            for (int i = 0; i < LivingPeople.Count; i++)
            {
                var person = LivingPeople[i];
                if (person.IsDying())
                {
                    DeadPeople.Add(new Dead(person));
                    WriteLine($"{person.FamilyName} {person.GivenName} died at the age of {person.Age}");
                    LivingPeople.Remove(person);
                    if (Bakfis.Contains(person))
                        Bakfis.Remove(person);
                }
            }

            foreach (var living in LivingPeople)
            {
                if(!living.Naimisissä && living.Age>16)
                {//házasuló korban, és hajlandóságban vannak (elég idősek, és még nem házasok)
                    if (living.Gender == Sex.FEMALE)
                        Bakfis.Add(living);
                    else //item.Gender == Sex.MALE
                    {
                        if(Bakfis.Count>0)
                        {
                            Families.Add(new Family(Bakfis[0], living));
                            WriteLine($"New family: {Families[Families.Count - 1].Spouses}");
                            Bakfis.RemoveAt(0);
                        }
                    }
                }
            }

            foreach (var family in Families)
            {
                if(family.GetChild())
                {
                    WriteLine($"{family.Spouses} got child");
                    family.NewChild();
                }
            }

        }
    }
}
