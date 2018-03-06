using System;
using System.Collections.Generic;


namespace Puzzles
{
    class Program
    {

        public static void RandomArray()
        {

            Random rand = new Random();
            int [] randarray = new int [10];
            int sum = new int();
            
            for (int i = 0; i <10; i++)
            {

                randarray[i] = rand.Next(5,26);
                sum+=randarray[i];

            }
            int max = randarray[0];
            int min = randarray[0];

            for (int j = 0; j<10;j++)
            {
                if ( max < randarray[j])
                {
                    max = randarray[j];
                }
                if ( min > randarray[j])
                {
                    min = randarray[j];
                }
            }

            System.Console.WriteLine(randarray);
            System.Console.WriteLine(max);
            System.Console.WriteLine(min);
            System.Console.WriteLine(sum);
        }

        

        public static string CoinFlip()
        {
            System.Console.WriteLine("Tossing a coin...");
            Random flip = new Random ();
            int results = flip.Next(1,3);
            string tossResult = "";

            if (results == 1)
            {
                 tossResult = "It's a heads.";
            }
            else{
                 tossResult = "It's a tails.";
            }
            

            return tossResult;


        }

        public static double TossMultipleCoins(int num)
        {
            string toss;
            double sumhead = 0;
            double sumtail = 0; 
            for (int i =0; i < num; i++)
            {
                toss = CoinFlip();
                System.Console.WriteLine(toss);
                if (toss == "It's a heads.")
                {
                    sumhead+=1;
                }
                if (toss == "It's a tails.")
                {
                    sumtail+=1;
                }
                
            }
                double result = sumhead/sumtail;
                System.Console.WriteLine(result);
                return result;
        }


        public static string[] Names()
        {
            string [] newArray = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            string holder = "";

            for (int i = 0; i < newArray.Length; i++)
            {
                int index = rand.Next(i, newArray.Length);
                holder = newArray[i];
                newArray[i] = newArray[index];
                newArray[index]=holder;
            }
            
            System.Console.WriteLine(newArray);
            List<string> longName = new List<string>();
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i].Length > 5)
                {
                    longName.Add(newArray[i]);
                }
            }


            string[] longNames = longName.ToArray();
            for (int i = 0; i < longNames.Length; i++)
            {
                System.Console.WriteLine(longNames[i]);
            }

            
            return newArray;
        }


        static void Main(string[] args)
        {
            
            // RandomArray();

//-----------------------------------------------------------


            // string toss;
            // toss=CoinFlip();
            // System.Console.WriteLine(toss);


//-----------------------------------------------------------

            // int tossnumber = 10;
            // double ratio = TossMultipleCoins(tossnumber);
            // System.Console.WriteLine("The ratio of heads to tails is {0}", ratio.ToString());


//-----------------------------------------------------------


            Names();

        }
    }
}
