using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public Guid ID { get; set; }
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
        /// The family in which the agent belongs to.
        /// </summary>
        public int BirthYear { get; protected set; }
        /// <summary>
        /// The year of death of the Agent.
        /// </summary>
        public int DeathYear { get; protected set; }

        public ICollection<Family> Families { get; } = new List<Family>();
    }

}
