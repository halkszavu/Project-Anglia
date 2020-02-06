using System;
using System.Diagnostics;

namespace Project_Anglia.Data
{
    enum Sex
    {
        MALE,
        FEMALE
    }

    [DebuggerDisplay("{Name}")]
    /// <summary>
    /// An acting agent in the simulation, with name, family and age.
    /// </summary>
    abstract class Agent
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

        public Family? Issue { get; set; }
#nullable disable
        public Guid ID { get; protected set; } = Guid.NewGuid();

        public string Name => $"{FamilyName} {GivenName}";

        public int CommonAncestor(Agent agent)
        {
            if (Parentage == null || agent.Parentage == null)
                return 0;
            if (Parentage == agent.Parentage)
                return 1;
            else
            {
                return Math.Min(Parentage.Father.CommonAncestor(agent.Parentage.Father), Parentage.Mother.CommonAncestor(agent.Parentage.Mother));
            }
        }
    }

}
