using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai

{
    public class Ninja : Human

    {
        public Ninja (string name) : base(name)
        {
            dexterity = 175;
        }

        public void steal (Human human)
        {
            this.health += 10;
            System.Console.WriteLine($"{this.name} has gained 10 health and now has {this.health}");
        }

        public void getAway()
        {
            this.health -= 15;
            System.Console.WriteLine($"{this.name} ran away and lost 15 health. {this.health} is remaining.");
        }
    }
    
}