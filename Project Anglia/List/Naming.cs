using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Anglia.List
{
    static partial class Naming
    {
        static Random random = new Random();

        public static string BoyName() => Fiuk[random.Next(Fiuk.Count)];

        public static string GirlName() => Lanyok[random.Next(Lanyok.Count)];

        public static string GetSurname()
        {
            if (Sukunimi.Count > 0)
            {
                int x = random.Next(Sukunimi.Count);
                string ret = Sukunimi[x];
                Sukunimi.RemoveAt(x);
                return ret;
            }
            else
                throw new Exception("Out of names to deal from.");
        }
    }
}
