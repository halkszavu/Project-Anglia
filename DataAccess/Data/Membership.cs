using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Anglia.Data
{
    enum MembershipType
    {
        Children,
        Father,
        Mother,
    }

    class Membership
    {
        public int ID { get; set; }
        public MembershipType MembershipType { get; set; }

        public Guid FamilyID { get; set; }
        public Family Family { get; set; }

        public Guid AgentID { get; set; }
        public Agent Agent { get; set; }
    }
}
