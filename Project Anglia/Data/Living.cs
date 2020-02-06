using Project_Anglia.List;
using System;
using System.Diagnostics;

namespace Project_Anglia.Data
{
    [DebuggerDisplay("{Name} : {Age}")]
    class Living : Agent
    {
        static protected Random random = new Random();

        public static Living GetLiving()
        {
            Living living = new Living
            {
                Gender = random.NextDouble() > 0.5D ? Sex.FEMALE : Sex.MALE,
                BirthYear = Program.Year,
                Parentage = null,
                FamilyName = Naming.GetSurname()
            };

            Living r;

            switch (living.Gender)
            {
                case Sex.MALE:
                    living.GivenName = Naming.BoyName();
                    r = living as Boy;
                    break;
                case Sex.FEMALE:
                    living.GivenName = Naming.GirlName();
                    r = living as Girl;
                    break;
                default:
                    throw new Exception("Genderless agent!");
            }

            return r;
        }
        public static Living Born(Family parentage)
        {
            Living living = new Living
            {
                Gender = random.NextDouble() > 0.5D ? Sex.FEMALE : Sex.MALE,
                BirthYear = Program.Year,
                Parentage = parentage,
                FamilyName = parentage.Father.FamilyName
            };

            switch (living.Gender)
            {
                case Sex.MALE:
                    living.GivenName = Naming.BoyName();
                    return living as Boy;
                case Sex.FEMALE:
                    living.GivenName = Naming.GirlName();
                    return living as Girl;
                default:
                    throw new Exception("Genderless agent!");
            }
        }

        public int Age => Program.Year - BirthYear;
        public bool Naimisissä => Issue != null;

        public bool IsDying()
        {
            double c = random.NextDouble();
            if (Age > 150)
                return c < 0.5;
            else if (Age > 80)
                return c < 0.2;
            else if (Age > 45)
                return c < 0.05;
            else if (Age > 20)
                return c < 0.01;
            else
                return c < 0.0005;
        }
    }
}
