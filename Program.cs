﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Heist();
        }

        static void Heist()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"                   Plan your Heist");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Add your first team member!");
            AddTeamMember();
        }

        //A place to store ALL team members
        static public List<TeamMember> TeamMemberList = new List<TeamMember>();

        // static public List<TeamMember>? TeamMemberList;

        static void AddTeamMember()
        {
            string name;
            string skill;
            string courage;
            int parsedSkill;
            decimal parsedCourage;

            //GET NEW TEAM MEMBER'S NAME FROM USER
            Console.Write("What is the new Team Member's NAME?");

            try
            {
                name = Console.ReadLine();

                //GET NEW TEAM MEMBER'S SKILL LEVEL FROM USER
                Console.WriteLine("What is the new Team Member's SKILL LEVEL?");
                Console.Write("Enter a number between 1 and 50:");

                skill = Console.ReadLine();
                parsedSkill = int.Parse(skill);

                //GET NEW TEAM MEMBER'S COURAGE FACTOR FROM USER
                Console.WriteLine("What is the new Team Member's COURAGE FACTOR?");
                Console.Write("Enter a number between 0.0 and 2.0:");

                courage = Console.ReadLine();
                parsedCourage = Decimal.Parse(courage);

                //Make a new TeamMember object using the TeamMember class
                var newTeamMember = new TeamMember(name, parsedSkill, parsedCourage);

                //add new TeamMember to List of Team Members (TeamMemberList)
                TeamMemberList.Add(newTeamMember);

                Console.WriteLine($"You now have {TeamMemberList.Count} members on your team!");

                foreach (TeamMember member in TeamMemberList)
                {
                    Console.WriteLine(
                        $"{member.Name} has a skill level of {member.SkillLevel} and a courage factor of {member.CourageFactor}"
                    );
                }
                ;

                //ASK USER IF THEY'D LIKE TO ADD ANOTHER TEAM MEMBER
                AddAnother();
            }
            catch (Exception exp)
            {
                //PROMPT USER TO ENTER VALID RESPONSE IF CAN'T PARSE
                Console.WriteLine("Please enter a valid response");

                AddTeamMember();
            }

            // if(Int32.TryParse(skill, out parsedSkill)){

            // }

            // else{Console.WriteLine("Please enter a valid number between 1 and 10");}
        }

        static void AddAnother()
        {
            Console.WriteLine();
            Console.Write($"Would you like to add another team member? (Y/N):");
            string answer = Console.ReadLine().ToLower();

            while (answer != "y" && answer != "n")
            {
                Console.Write($"Would you like to add another team member? (Y/N):");
                answer = Console.ReadLine().ToLower();
            }

            if (answer == "y")
            {
                AddTeamMember();
            }
            else
            {
                CheckBankDifficulty();
            }
        }

        //Once team is built, check if skill level is higher than bank difficulty
        static void CheckBankDifficulty()
        {

            int BankDifficulty = 100;
            int TeamSkillLevel = TeamMemberList.Sum(member => member.SkillLevel);

            Console.WriteLine($"The teams skill level is {TeamSkillLevel} and the bank difficulty is {BankDifficulty}");

            if (BankDifficulty > TeamSkillLevel)
            {
                Console.WriteLine($"Sorry, you're going to have to build a better team to rob this bank.");
                Heist();
            }

            else
            {
                Console.WriteLine($"Congratulations! Your team has the skill required to rob this bank.");
                Heist();
            }
        }







    }
}
