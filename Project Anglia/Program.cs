using Project_Anglia.Data;
using System.Collections.Generic;
using System.Linq;
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
            bool folyt = true;
            while(folyt)
            {
                //PassYear();
                WriteLine("Do you want to finish the simulation? y/n");
                if (ReadLine() == "y")
                {
                    folyt = false;
                    continue;
                }
                WriteLine("How many year do you want to jump?");
                string yrs;
                int y;
                do
                {
                    yrs = ReadLine();
                } while (!int.TryParse(yrs, out y));
                for (int i = 0; i < y; i++)
                {
                    PassYear();
                }
            }

            WriteLine("FINISHING SIMULATION");
            System.Threading.Thread.Sleep(800);
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
                    Dead dead = new Dead(person);
                    DeadPeople.Add(dead);
                    WriteLine($"{person.FamilyName} {person.GivenName} died at the age of {person.Age}");
                    LivingPeople.Remove(person);
                    if (Bakfis.Contains(person))
                        Bakfis.Remove(person);
                    if (Families.Count > 0)
                    {
                        var x = Families.Where(f => f.Mother.ID == person.ID).ToList();
                        x.AddRange(Families.Where(f => f.Father.ID == person.ID).ToList());
                        foreach(var item in x)
                        {
                            if (item.Father.ID == person.ID)
                                item.FatherDied(dead);
                            if (item.Mother.ID == person.ID)
                                item.MotherDied(dead);
                        }
                    }
                }
            }

            foreach (var living in LivingPeople)
            {
                if(!living.Naimisissä && living.Age>16)
                {//házasuló korban, és hajlandóságban vannak (elég idősek, és még nem házasok)
                    if (living.Gender == Sex.FEMALE && !Bakfis.Contains(living))
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
                if (family.DeadParent || family.Mother is Living livingMom && livingMom.Age > 45)
                    continue;
                if(family.GetChild())
                {
                    WriteLine($"{family.Spouses} got child");
                    family.NewChild();
                }
            }

        }
    }
}
