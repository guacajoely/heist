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
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"                   Plan your Heist                  ");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();

            try
            {
                Console.WriteLine("Please choose a bank difficulty between 1 and 100");
                Console.Write("Difficulty: ");

                string userDifficulty = Console.ReadLine();
                parsedDifficulty = int.Parse(userDifficulty);

                // // CHECK THAT USER ENTERED DIFFICULTY BETWEEN 1 AND 100
                if (parsedDifficulty < 0 || parsedDifficulty > 100)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid response");
                    Heist();
                }

                Console.WriteLine();
                Console.WriteLine("Add your first team member!");
                AddTeamMember();
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid response");
                Heist();
            }
        }

        // STORE ALL TEAM MEMBERS
        static public List<TeamMember> TeamMemberList = new List<TeamMember>();

        // STORE THE DIFFICULTY ENTERED BY THE USER
        static public int parsedDifficulty;

        // STORE SUCCESSFUL HEISTS
        static public int successfulHeists;

        static void AddTeamMember()
        {
            string name;
            string skill;
            string courage;
            int parsedSkill;
            decimal parsedCourage;

            // GET NEW TEAM MEMBER'S NAME FROM USER
            Console.WriteLine();
            Console.Write("What is the new Team Member's NAME?: ");

            try
            {
                name = Console.ReadLine();

                // GET NEW TEAM MEMBER'S SKILL LEVEL FROM USER
                Console.WriteLine();
                Console.WriteLine("What is the new Team Member's SKILL LEVEL?");
                Console.Write("Enter a number between 1 and 50: ");

                skill = Console.ReadLine();
                parsedSkill = int.Parse(skill);

                // CHECK THAT USER ENTERED SKILL LEVEL BETWEEN 1 AND 50
                if (parsedSkill < 0 || parsedSkill > 50)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid response");
                    AddTeamMember();
                }

                // GET NEW TEAM MEMBER'S COURAGE FACTOR FROM USER
                Console.WriteLine();
                Console.WriteLine("What is the new Team Member's COURAGE FACTOR?");
                Console.Write("Enter a number between 0.0 and 2.0: ");

                courage = Console.ReadLine();
                parsedCourage = Decimal.Parse(courage);

                // CHECK THAT USER ENTERED COURAGE FACTOR BETWEEN 0 AND 2
                if (parsedCourage < 0 || parsedCourage > 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid response");
                    AddTeamMember();
                }

                // CREATE A NEW TEAMMEMBER OBJECT USING THE TEAMMEMBER CLASS
                var newTeamMember = new TeamMember(name, parsedSkill, parsedCourage);

                // ADD NEW TEAMMEMBER TO LIST DECLARED AT START
                TeamMemberList.Add(newTeamMember);

                Console.WriteLine();
                Console.WriteLine($"You now have {TeamMemberList.Count} member/s on your team!");

                foreach (TeamMember member in TeamMemberList)
                {
                    Console.WriteLine(
                        $"{member.Name} has a skill level of {member.SkillLevel} and a courage factor of {member.CourageFactor}"
                    );
                }
                ;

                // ASK USER IF THEY'D LIKE TO ADD ANOTHER TEAM MEMBER
                AddAnother();
            }

            catch
            {
                // PROMPT USER TO ENTER VALID RESPONSE IF CAN'T PARSE
                Console.WriteLine();
                Console.WriteLine("Please enter a valid response");

                AddTeamMember();
            }
        }

        static void AddAnother()
        {
            Console.WriteLine();
            Console.Write($"Would you like to add another team member? (Y/N): ");
            string answer = Console.ReadLine().ToLower();

            while (answer != "y" && answer != "n")
            {
                Console.Write($"Would you like to add another team member? (Y/N): ");
                answer = Console.ReadLine().ToLower();
            }

            if (answer == "y")
            {
                AddTeamMember();
            }
            else
            {
                RunHeist();
            }
        }

        static void RunHeist()
        {
            Console.WriteLine();
            Console.Write($"How many times would you like to trial run the heist? (max 100): ");
            string answer = Console.ReadLine().ToLower();

            try
            {
                int parsedAnswer = int.Parse(answer);

                // CHECK THAT USER ENTERED HEIST AMOUNT BETWEEN 1 AND 100
                if (parsedDifficulty < 0 || parsedDifficulty > 100)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid response");
                    RunHeist();
                }

                for (int i = 0; i < parsedAnswer; i++)
                {
                    TrialRun();
                }

                Console.WriteLine();
                Console.WriteLine($"HEIST REPORT");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"{successfulHeists} of {answer} heists were successful");
                Console.WriteLine();
                Replay();
            }
            catch (Exception exp)
            {
                // PROMPT USER TO ENTER VALID RESPONSE IF CAN'T PARSE
                Console.WriteLine();
                Console.WriteLine("Please enter a valid response");

                RunHeist();
            }
        }

        // FUNCTION THAT CHECKS IF BANK DIFFICULTY IS HIGHER THAN TEAM SKILL (FAIL) or LOWER (SUCCESS)
        static void TrialRun()
        {
            // CREATE BANKDIFFICULTY MODIFIER NAMED LUCK VALUE AND ADD TO BANK DIFFICULTY ENTERED BY USER
            int luckValue = new Random().Next(-10, 10);

            int BankDifficulty = parsedDifficulty + luckValue;
            int TeamSkillLevel = TeamMemberList.Sum(member => member.SkillLevel);

            Console.WriteLine();
            Console.WriteLine(
                $"Your team's skill level is {TeamSkillLevel} and the bank difficulty is {BankDifficulty}"
            );

            if (BankDifficulty > TeamSkillLevel)
            {
                Console.WriteLine($"Sorry, your team failed this heist.");
            }
            else
            {
                Console.WriteLine($"Congratulations! Your team successfully robbed the bank.");
                successfulHeists++;
            }
        }

        // ONCE GAME ENDS PROMPT PLAY AGAIN QUESTION
        static void Replay()
        {
            Console.WriteLine();
            Console.Write($"Play Again? (Y/N):");
            string answer = Console.ReadLine().ToLower();

            while (answer != "y" && answer != "n")
            {
                Console.Write($"Play Again? (Y/N):");
                answer = Console.ReadLine().ToLower();
            }

            if (answer == "y")
            {
                //CLEAR GLOBAL VARIABLES FROM PREVIOUS HEIST
                successfulHeists = 0;
                TeamMemberList = new List<TeamMember>();
                Heist();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
