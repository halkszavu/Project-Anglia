﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Project_Anglia.Data
{
    [DebuggerDisplay("{Name} : {Age}")]
    class Boy : Living
    {
        public Boy(Living living)
        {
            Gender = Sex.MALE;

            FamilyName = living.FamilyName;
            GivenName = living.GivenName;
            BirthYear = living.BirthYear;
            Parentage = living.Parentage;
            Issue = living.Issue;
            ID = living.ID;
        }

        public bool IsProposing()
        {
            if (Naimisissä || Age < 14)
                return false;
            else
                return random.NextDouble() < 0.2F;
        }

        public Girl Propose(IEnumerable<Girl> bakfis)
        {
            var x = bakfis.OrderBy(g => Math.Abs(g.BirthYear - BirthYear));

            foreach (var item in x)
            {
                int y = LowestCommonAncestor(this, item);
                if (y > 0 && y < 5)
                    continue;
                else
                    return item;
            }

            throw new NoSuitorException("No suitable girl found");
        }
    }
}
