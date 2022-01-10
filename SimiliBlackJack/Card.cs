using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class Card
    {
        private string suit = "";
        private string rank = "";
        private int value = 0;
       

        public Card(string suit, string rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
        //Adding value to the card
        public void SetValue(int value)
        {
            this.value = value;
        }
        public string GetRank()
        {
            return rank;
        }
        public void AfficherCard()
        {
            Console.WriteLine("Card: {0} of {1}", rank, suit);
        }
        public int GetValue()
        {
            return value;
        }
    }
}
