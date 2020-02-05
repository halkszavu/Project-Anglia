using Project_Anglia.Data;
using System.Collections.Generic;
using static System.Console;

namespace Project_Anglia
{
    class Program
    {
        public static List<Living> LivingPeople { get; set; }
        public static List<Dead> Deads { get; set; }
        public static List<Family> Families { get; set; }

        public static int Year { get; protected set; }

        static void Main(string[] args)
        {
            Init();
            for (int i = 0; i < 100; i++)
                PassYear();

            WriteLine("FINISHING SIMULATION");
            ReadKey();
        }

        static void Init()
        {
            Year = 0;
            WriteLine("STARTING SIMULATION:");
        }

        static void PassYear()
        {
            Year++;
            WriteLine($"Year {Year}");
            WriteLine($"Living: {LivingPeople.Count}");
        }
    }
}
