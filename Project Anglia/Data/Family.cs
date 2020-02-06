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

        public bool DeadParent { get; set; }

        public Family(Living mother, Living father)
        {
            Mother = mother;
            Father = father;

            mother.Naimisissä = true;
            father.Naimisissä = true;

            DesiredChildren = ChildrenCount();
        }

        int ChildrenCount()
        {
            return Math.Max(Convert.ToInt32(Gauss(2, 4)), 0);
        }
        
        private double Gauss(double mean, double stdDev)
        {
            double u1 = 1.0 - random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            return mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        }

        public bool GetChild() => Children.Count < DesiredChildren;

        public string Spouses => $"{Father.Name} - {Mother.Name}";

        public void NewChild()
        {
            Living child = new Living(this);
            Program.LivingPeople.Add(child);
            Children.Add(child);
        }

        public void FatherDied(Dead father) => Father = father;
        public void MotherDied(Dead mother) => Mother = mother;
    }
}
