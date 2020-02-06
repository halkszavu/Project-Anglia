using Project_Anglia.List;
using System;
using System.Collections.Generic;

namespace Project_Anglia.Data
{
    enum Sex
    {
        MALE,
        FEMALE
    }

    /// <summary>
    /// An acting agent in the simulation, with name, family and age.
    /// </summary>
    class Agent
    {
        /// <summary>
        /// Familyname is always inherited from the father, it can't be changed after birth.
        /// </summary>
        public string FamilyName { get; protected set; }
        /// <summary>
        /// Given name is always created at birth, it can't be changed later.
        /// </summary>
        public string GivenName { get; protected set; }
        public Sex Gender { get; protected set; }
        /// <summary>
        /// The year in which the Agent was born.
        /// </summary>
        public int BirthYear { get; protected set; }
#nullable enable
        public Family? Parentage { get; protected set; }
#nullable disable
        public Guid ID { get; protected set; } = Guid.NewGuid();

        public string Name => $"{FamilyName} {GivenName}";
    }

    class Living : Agent
    {
        static Random random = new Random();

        public int Age => Program.Year - BirthYear;
        public bool Naimisissä { get; set; }

        public Living(Family parentage = null)
        {
            if (parentage == null)
                FamilyName = Naming.GetSurname();
            else
            {
                Parentage = parentage;
                FamilyName = Parentage.Father.FamilyName;
            }
            BirthYear = Program.Year;
            Gender = random.NextDouble() > 0.5D ? Sex.FEMALE : Sex.MALE;
            switch (Gender)
            {
                case Sex.MALE:
                    GivenName = Naming.BoyName();
                    break;
                case Sex.FEMALE:
                    GivenName = Naming.GirlName();
                    break;
            }
        }

        public bool IsDying() => random.NextDouble() < 0.01D;
    }

    class Dead : Agent
    {
        /// <summary>
        /// The year of death of the Agent.
        /// </summary>
        public int DeathYear { get; protected set; }

        public Dead(Living living)
        {
            DeathYear = Program.Year;
            FamilyName = living.FamilyName;
            GivenName = living.GivenName;
            Gender = living.Gender;
            BirthYear = living.BirthYear;
            Parentage = living.Parentage;
        }
    }
}
