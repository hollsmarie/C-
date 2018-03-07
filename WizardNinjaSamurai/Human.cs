using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai

{
    public class Human
    {
        public string name;

        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }



        public Human(string n)
        {

            name = n;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        public Human(string n, int s, int i, int d, int h)
        {
            name = n;
            strength = s;
            intelligence = i;
            dexterity = d;
            health = h;
        }

        public void attack(object name)
        {
            Human jerk = name as Human;
            if (jerk == null)
            {
                System.Console.WriteLine("Failed Attack");
            }
            
            else
            {
                jerk.health -= strength * 5;
            }
            // int damage = 5 * strength;
            // jerk.health -= damage;
            // // System.Console.WriteLine($"{this.name} attacked {jerk.name}. {jerk.name}'s health is now {jerk.health}");
            // return jerk;
        }

    }





}
