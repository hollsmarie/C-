using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<object> listy = new List<object>();

            listy.Add(7);
            listy.Add(28);
            listy.Add(true);
            listy.Add("chair");
            int sum = new int();
            
            foreach (var entry in listy)
            {
                Console.WriteLine(entry);
                if (entry is int)
                {
                    sum+= (int)entry;
                }
            }
            Console.WriteLine(sum);

        }
    }
}
