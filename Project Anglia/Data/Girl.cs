using System.Diagnostics;

namespace Project_Anglia.Data
{
    [DebuggerDisplay("{Name} : {Age}")]
    class Girl : Living
    {
        public Girl(Living living)
        {
            Gender = Sex.FEMALE;

            FamilyName = living.FamilyName;
            GivenName = living.GivenName;
            BirthYear = living.BirthYear;
            Parentage = living.Parentage;
            Issue = living.Issue;
            ID = living.ID;
        }

        public bool WantToMarry()
        {
            if (Naimisissä || Age < 13)
                return false;
            else
                return random.NextDouble() < 0.05F;
        }
    }
}
