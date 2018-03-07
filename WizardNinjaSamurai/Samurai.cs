using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai

{

    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }

        public void deathBlow(Human human)
        {
            if (human.health <50)
            {
                human.health = 0;
                System.Console.WriteLine($"{human.name} Has been death blown.");
            }
            else
            {
                System.Console.WriteLine("Attack has missed!");
            }
        }

        public void meditate()
        {
            this.health = 200;
            System.Console.WriteLine($"{this.name} is back to full health!");
        }

    }
}