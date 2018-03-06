using System;
namespace Human

{
    public class Human
    {
        public string name;
        public int strength;
        public int intelligence;
        public int dexterity;
        public int health;


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
            name=n;
            strength=s;
            intelligence=i;
            dexterity=d;
            health=h;
        }

        public Human attack(Human jerk)
        {
            int damage = 5*strength;
            jerk.health -= damage;
            System.Console.WriteLine($"{this.name} attacked {jerk.name}. {jerk.name}'s health is now {jerk.health}");
            return jerk;
        }

    }





}
