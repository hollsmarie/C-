using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
    


            int [] arr = new int[10];
            for (int i =0; i < 10; i++)
            {
                arr[i] = i;
                Console.WriteLine(i);
            }
            


            string [] names = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }


            bool [] truefalse = new bool [10];
            for (int i=0; i <10; i++)
            {
                if (i % 2 == 0)
                {
                  truefalse[i] = true;  
                }
                else
                {
                  truefalse[i] = false;
                }
            }

            foreach (bool factoid in truefalse){
                Console.WriteLine(factoid);
            }

            


            // multiplication table 1-100

            int [,] multTable= new int[10,10];
            for (int i = 0; i<=9; i ++)
            {
                for (int j = 0; j <=9; j ++)
                {
                    multTable[i,j] = (i+1)* (j+1);
                    Console.Write(multTable[i,j] + "\t");
                }
                Console.WriteLine();
            }

            //List of Flavors
            
            List<string> flavors = new List<string>();

            flavors.Add("Strawberry");
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Schnozberry");
            flavors.Add("Dirt");
            
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);


            //User Info Dictionary

            Dictionary<string,string> bio = new Dictionary<string,string>();

            foreach(string name in names)
            {
                bio.Add(name, null);
                Console.WriteLine(name);
            }
    
            Random rand = new Random();

            List<string> keys = new List<string>(bio.Keys);
            for (int i = 0; i < keys.Count; i ++)
            {
                bio[keys[i]] = flavors [rand.Next (0,3)];
            }

            foreach(var entry in bio)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }


        }
    }
}
