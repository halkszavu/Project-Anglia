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
        public Family Parentage { get; protected set; }
    }

    class Living : Agent
    {
        public int Age => Program.Year - BirthYear;


    }

    class Dead : Agent
    {
        /// <summary>
        /// The year of death of the Agent.
        /// </summary>
        public int DeathYear { get; protected set; }
    }
}
