using System.Diagnostics;

namespace Project_Anglia.Data
{
    [DebuggerDisplay("{Name} {BirthYear}-{DeathYear}")]
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
