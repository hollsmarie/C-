using System;
using System.Collections.Generic;
namespace DeckOfCards


{

    public class Deck
    {

        public List<Card> cards = new List<Card>(); //making a list of the card makes it refer to the object Card

        public Deck reset()
        {
            string[] suits = { "Diamonds", "Hearts", "Clubs", "Spades" };
            string[] stringVals = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach (string suit in suits)
            {
                for (int i = 0; i < stringVals.Length; i++)
                {
                    Card newCard = new Card(suit, stringVals[i], i++);
                    cards.Add(newCard);  //add to the list of cards created above

                }
            }
            return this;
        }

        public Deck deal()
        {
            if(cards.Count > 0)
            {
                Card first = cards[0];
                cards.RemoveAt(0);
                return first;
            }
            else{
                reset();
                return deal();
            }

        }


        public void shuffle()
        {
            
            Random rand = new Random();
            for (int end=cards.Count - 1; end>=0; end --)
            {
                int shuffle = rand.Next(0, cards.Count-1);

                Card temp = cards[shuffle];
                cards[shuffle] = cards[end];
                cards[end] = temp;
            }



        }
    }

}