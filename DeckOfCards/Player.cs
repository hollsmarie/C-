using System;
using System.Collections.Generic;
namespace DeckOfCards


{
    public class Player
    {
        string name; //player has a name attribute
        public List<Card> hand; //player has hand property 

        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }

        public Card draw (Deck addhand)

        {
            Card newCard = addhand.deal();
            hand.Add(newCard);
            return newCard;
        }

        public Card discard (int idx)
        {
            if (idx < 0 || idx > hand.Count){
                return null;
            }
            else 
            {
                Card shuffle = hand[idx];
                hand.RemoveAt(idx);
                return shuffle;
            }
        }
    }


    
}