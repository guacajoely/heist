using System;
using System.Collections.Generic;

namespace Heist
{
    public class TeamMember
    {
        public string Name { get; set;}
        public int SkillLevel { get; set;}
        public decimal CourageFactor { get; set;}

        public TeamMember(string name, int skill, decimal courage)
        {
            Name = name;
            SkillLevel = skill;
            CourageFactor = courage;
        }

    }
}