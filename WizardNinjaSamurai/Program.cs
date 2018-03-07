using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Human Terrance = new Human("Terrance");
            Human Bob = new Human("Bob");

            Terrance.attack(Bob);
        }
    }
}
