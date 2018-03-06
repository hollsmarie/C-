using System;

using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //print 1-255

            // for (int i = 1; i < 256; i++)
            // {
            //     Console.WriteLine(i);
            // }

//------------------------------------------------------------------

            //print odd 1-255

            // for (int i = 1; i < 256; i++)
            // {
            //     if (i % 2 == 1)
            //     {
            //         Console.WriteLine(i);
            //     }
            // }
//------------------------------------------------------------------

            //print sum

            // int sum = new int();
            // for (int i = 0; i <256; i++)
            // {
            //     sum += i;
            //     Console.WriteLine("New number: " +i+ "Sum: " + sum);
            // }

  //------------------------------------------------------------------          

            //iterate thrugh array

            // int [] newArray = {1,3,5,7,9,13};

            // foreach (int number in newArray)
            // {
            //     Console.WriteLine(number);
            // }

//------------------------------------------------------------------


            //find max

            // int [] maxArray = {-4,58,9,0,13};
            // int max = maxArray[0];

            // foreach (int numb in maxArray)
            // {
            //     if (numb > max)
            //     {
            //         max = numb;
            //     }
            // }
            // Console.WriteLine(max);

//------------------------------------------------------------------

            //get average

            // int [] avgArray = {2,10,3};
            // int sum = new int();

            // foreach (int numero in avgArray)
            // {
            //     sum += (int)numero;

            // }
            // int avg = sum/avgArray.Length;
            // Console.WriteLine(avg);

//------------------------------------------------------------------

            //array with odd numbers

            // List<int> tempList = new List<int>();

            // for (int i = 1; i <256; i++)
            // {
            //     if (i % 2 == 1)
            //     {
            //         tempList.Add(i);
            //     }
            // }
            // int [] Y =  tempList.ToArray();
            // Console.WriteLine(Y);

//------------------------------------------------------------------


            //greater than Y

            // int Y = 3;
            // int[] thisarray = {1,3,5,7};
            // int count = 0;

            // for (int i = 0; i < thisarray.Length; i++)
            // {
            //     if (thisarray[i] > Y)
            //     {
            //         count++;
            //     }
            // }
            // System.Console.WriteLine(count);

//------------------------------------------------------------------


            //square the values

            // int [] x = {1,5,10,-2};

            // for (int i = 0; i < x.Length; i++)
            // {
            //     x[i] = x[i] * x[i];
            //     System.Console.WriteLine(x[i]);
            // }
        

//------------------------------------------------------------------

            // eliminate negative numbers

            // int [] x = {1,5,10,-2};

            // for (int i = 0; i < x.Length; i++)
            // {
            //     if (x[i] < 0)
            //     {
            //         x[i]=0;
            //     }
            // }
            // System.Console.WriteLine(x);



//___________________________________________________

            //min,max,avg

            // int[] x = {1,5,10,-2};
            // int max = x[0];
            // int min = x[0];
            // int sum = new int();

            // for (int i = 0; i < x.Length; i++)
            // {
            //     if (max < x[i])
            //     {
            //         max = x[i];
            //     }

            //     if (min > x[i])
            //     {
            //         min = x[i];
            //     }

            //     sum = sum + x[i];

            // }

            // int avg = sum/x.Length;

            // int [] mmaArray = {max, min, avg};
            
            // System.Console.WriteLine(mmaArray);


//----------------------------------------------------


            //shifting the values in an array

            // int [] x = {1,5,10,7,-2};

            // for (int i = 0; i < x.Length; i++)
            // {
            //     if (x[i] == x[x.Length-1])
            //     {
            //         x[i] = 0;
            //     }
            //     else
            //     {
            //     x[i] = x[i+1];
            //     }
                
            // }

            // System.Console.WriteLine(x);



            // number to string UNFINISHED

            // int [] x = {-1,-3,2};
            // string dojo = "Dojo";

            // for (int i = 0; i < x.Length; i++)
            // {
            //     if (x[i] < 0)
            //     {
            //         x[i]= "Dojo";
            //     }
            // }
            // System.Console.WriteLine(x);

        }

    }
}
