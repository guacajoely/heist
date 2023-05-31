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

            AddTeamMember();
           

        }


        static void AddTeamMember()
        {

             string name;
             string skill;
             string courage;
             int parsedSkill;
             decimal parsedCourage;


            //GET NEW TEAM MEMBER'S NAME FROM USER
            Console.Write("What is the new Team Member's NAME?");
            name = Console.ReadLine();

            //GET NEW TEAM MEMBER'S SKILL LEVEL FROM USER
            Console.WriteLine("What is the new Team Member's SKILL LEVEL?");
            Console.Write("Enter a number between 1 and 10:");
            skill = Console.ReadLine();

            try{
                
                parsedSkill = int.Parse(skill);

                //GET NEW TEAM MEMBER'S COURAGE FACTOR FROM USER
                Console.WriteLine("What is the new Team Member's COURAGE FACTOR?");
                Console.Write("Enter a number between 0.0 and 2.0:");

                courage = Console.ReadLine();
                parsedCourage = Decimal.Parse(courage);

                //Make a new TeamMember object using the TeamMember class
                var newTeamMember = new TeamMember(name, parsedSkill, parsedCourage);

                Console.WriteLine($"{newTeamMember.Name} has a skill level of {newTeamMember.SkillLevel} and a courage factor of {newTeamMember.CourageFactor}");
            
        
            
            }

            catch(Exception exp){

                Console.WriteLine("Please enter a valid number");
                Console.WriteLine(exp);

                AddTeamMember();
            }

            // if(Int32.TryParse(skill, out parsedSkill)){

            // }

            // else{Console.WriteLine("Please enter a valid number between 1 and 10");}


          
        }
    }




}