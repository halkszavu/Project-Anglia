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
        public static List<Family> LivingFamilies { get; set; }

        static List<Girl> Bakfis;

        public static int Year { get; protected set; }

        static void Main(string[] args)
        {
            Init();
            bool folyt = true;
            while (folyt)
            {
                //PassYear();
                WriteLine("Do you want to finish the simulation? y/n");
                if (ReadLine() == "y")
                {
                    folyt = false;
                    continue;
                }
                WriteLine("List the familynames? y/n");
                if (ReadLine() == "y")
                    ListFamilyNames();
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
            Bakfis = new List<Girl>();
            LivingFamilies = new List<Family>();
            for (int i = 0; i < 2000; i++)
            {
                LivingPeople.Add(Living.GetLiving());
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
                    //WriteLine($"{person.FamilyName} {person.GivenName} died at the age of {person.Age}");
                    //Write('✝');
                    Write('+');
                    LivingPeople.Remove(person);
                    if (person is Girl girl && Bakfis.Contains(girl))
                        Bakfis.Remove(girl);
                    
                }
            }

            WriteLine();

            foreach (var living in LivingPeople)
            {
                if (living is Girl girl && !Bakfis.Contains(living) && girl.WantToMarry())
                    Bakfis.Add(girl);
                else //item.Gender == Sex.MALE
                {
                    var boy = living as Boy;
                    if (Bakfis.Count > 0 && boy.IsProposing())
                    {
                        try
                        {
                            Girl g = boy.Propose(Bakfis);
                            Family f = new Family(g, boy);
                            Families.Add(f);
                            LivingFamilies.Add(f);
                            //WriteLine($"New family: {Families[Families.Count - 1].Spouses}");
                            //Write('\u26AD');
                            Bakfis.Remove(g);
                            Write('o');
                        }
                        catch (NoSuitorException)
                        {
                            Write("x");
                            continue;
                        }
                    }
                }
            }

            WriteLine();

            foreach (var family in LivingFamilies)
            {
                if (family.GetChild())
                {
                    //WriteLine($"{family.Spouses} got child");
                    Write('.');
                    family.NewChild();
                }
            }

            WriteLine();
            WriteLine("STATS:");
            WriteLine($"Average number of children in families: {(float)LivingFamilies.Sum(f=>f.Children.Count)/(float)LivingFamilies.Count}");

        }

        static void ListFamilyNames()
        {
            WriteLine("Listing all the families by name and members:");

            List<Agent> agents = new List<Agent>();

            agents.AddRange(LivingPeople);
            //agents.AddRange(DeadPeople);

            foreach (var item in agents.GroupBy(a => a.FamilyName))
            {
                if (item.Count() > 5)
                    WriteLine("{0,-32} :{1}", item.Key, item.Count());
            }
        }
    }
}
