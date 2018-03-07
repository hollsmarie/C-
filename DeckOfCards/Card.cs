using System;
using System.Collections.Generic;
namespace DeckOfCards
{

    public class Card
    {

        public string stringval;
        public string suit;
        public int val;

        public Card(string newStringVal, string newSuit, int newVal)
        {
            stringval = newStringVal;
            suit = newSuit;
            val = newVal;
        }
        
    }


}