using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project_Anglia.Data
{
    /// <summary>
    /// A nuclear family of a father and a mother, and their children.
    /// </summary>
    [DebuggerDisplay("{Father.Name} - {Mother.Name}")]
    class Family
    {
        static Random random = new Random();
        public List<Agent> Children { get; } = new List<Agent>();

        public Agent Mother { get; protected set; }
        public Agent Father { get; protected set; }

        public Family(Living mother, Living father)
        {
            Mother = mother;
            Father = father;
            Mother.Issue = this;
            Father.Issue = this;
        }

        public bool GetChild()
        {
            if (Mother is Living mother && mother.Age > 45)
                return false;
            else
                return random.NextDouble() < 2F / (15F * Math.Pow(2, Children.Count));
        }

        public string Spouses => $"{Father.Name} - {Mother.Name}";

        public void NewChild()
        {
            Living child = Living.Born(this);
            Program.LivingPeople.Add(child);
            Children.Add(child);
        }

        public void FatherDied(Dead father) => Father = father;
        public void MotherDied(Dead mother) => Mother = mother;
    }
}
