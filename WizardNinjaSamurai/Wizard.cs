using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai

{

    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            intelligence = 25;
            health = 50;
        }

        public void heal()
        {
            health += intelligence*10;
        }
        public void fireball(Human human)
        {
            Random rand = new Random();
            int damage = rand.Next(20,51);
            human.health -= damage;
            System.Console.WriteLine($"{human.name} now has {human.health}");
        }
    }

    
}