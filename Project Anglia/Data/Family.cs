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

        public Family(Living mother, Living father)
        {
            Mother = mother;
            Father = father;

            mother.Naimisissä = true;
            father.Naimisissä = true;

            DesiredChildren = random.Next(10);
        }

        public bool GetChild() => Children.Count < DesiredChildren;

        public string Spouses => $"{Father.Name} - {Mother.Name}";

        public void NewChild()
        {
            Living child = new Living(this);
            Program.LivingPeople.Add(child);
            Children.Add(child);
        }
    }
}
