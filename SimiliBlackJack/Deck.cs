using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class Deck
    {

        private string[] arrSuits = { "♣", "♦", "♥", "♠" };
        private string[] arrRanks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        private static Random random = new Random();
        private List<Card> cardDeck = new List<Card>();
        

        
        public Deck()
        {
            
            foreach (string strSuit in arrSuits)
            {
                foreach (string strRank in arrRanks)
                {
                    cardDeck.Add(new Card(strSuit, strRank));
                }
            }
            AddValue();

        }
        public Card GetCard(int i)
        {
            return cardDeck[i];
        }
        private void AddValue()
        {
            foreach (Card tempCard in cardDeck)
            {
                switch (tempCard.GetRank())
                {
                    case "A":
                        tempCard.SetValue(11);
                        break;
                    case "2":
                        tempCard.SetValue(2);
                        break;
                    case "3":
                        tempCard.SetValue(3);
                        break;
                    case "4":
                        tempCard.SetValue(4);
                        break;
                    case "5":
                        tempCard.SetValue(5);
                        break;
                    case "6":
                        tempCard.SetValue(6);
                        break;
                    case "7":
                        tempCard.SetValue(7);
                        break;
                    case "8":
                        tempCard.SetValue(8);
                        break;
                    case "9":
                        tempCard.SetValue(9);
                        break;
                    case "10":
                        tempCard.SetValue(10);
                        break;
                    case "J":
                        tempCard.SetValue(10);
                        break;
                    case "Q":
                        tempCard.SetValue(10);
                        break;
                    case "K":
                        tempCard.SetValue(10);
                        break;
                    default:
                        tempCard.SetValue(0);
                        break;
                }
            }
        }
      
        public void Shuffle()
        {
            int n = cardDeck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = cardDeck[k];
                cardDeck[k] = cardDeck[n];
                cardDeck[n] = value;
            }
        }
    }
}
