using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();

            var query = Artists.Where(a => a.Hometown == "Atlanta").OrderByDescending(b => b.Age).Take(3);
           foreach (var artist in query)
           {
            
           System.Console.WriteLine(artist.RealName);
           
           }
           
           


            // //Collections to work with
            // List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            // List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
        //     List<Artist> Artists = JsonToFile<Artist>.ReadJson();
           
        //    var query = Artists.Where(a => a.Hometown == "Mount Vernon");
        //    foreach (var artist in query)
        //    {
            
        //    System.Console.WriteLine(artist.RealName);
        //    System.Console.WriteLine(artist.Age);
        //    }

            //Who is the youngest artist in our collection of artists?
        //     List<Artist> Artists = JsonToFile<Artist>.ReadJson();
           
        //    var query = Artists.OrderBy(a =>a.Age).Select(a => a.RealName).First();
    
        //    System.Console.WriteLine(query);





        //     //Display all artists with 'William' somewhere in their real name
        //     List<Artist> Artists = JsonToFile<Artist>.ReadJson();

        //     var query = Artists.Where(a => a.RealName.Contains("William")).ToList();;
        //    foreach (var artist in query)
        //    {
            
        //    System.Console.WriteLine(artist.RealName);
           
        //    }

            //Display the 3 oldest artist from Atlanta

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
