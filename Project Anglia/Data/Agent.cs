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

        static public int LowestCommonAncestor(Agent myside, Agent otherside)
        {
            return -1;
        }

        static public Agent LCA(Agent root, Agent p, Agent q)
        {
            if (root == null)
                return null;

            if (root == p || root == q)
                return root;

            else
            {
                Agent motherside = LCA(root.Parentage.Mother, p, q);
                Agent fatherside = LCA(root.Parentage.Father, p, q);

                if (motherside == null && fatherside == null)
                    return root;
                else if (motherside != null)
                    return motherside;
                else
                    return fatherside;
            }
        }
    }

}
