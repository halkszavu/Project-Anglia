using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_Anglia.Data
{
    /// <summary>
    /// A nuclear family of a father and a mother, and their children.
    /// </summary>
    class Family
    {
        public Guid ID { get; set; }
        /// <summary>
        /// The number of children the family will target.
        /// </summary>
        public int DesiredChildren { get; protected set; }
        public ICollection<Agent> Members { get; } = new List<Agent>();
    }
}
