using System;
using System.Collections.Generic;

namespace Project_Anglia.Data
{
    /// <summary>
    /// A nuclear family of a father and a mother, and their children.
    /// </summary>
    class Family
    {
        static Random random = new Random();
        /// <summary>
        /// The number of children the family will target.
        /// </summary>
        public int DesiredChildren { get; protected set; }
        public List<Agent> Children { get; } = new List<Agent>();

        public Agent Mother { get; protected set; }
        public Agent Father { get; protected set; }

        public Family(Agent mother, Agent father)
        {
            Mother = mother;
            Father = father;

            DesiredChildren = random.Next(10);
        }


    }
}
