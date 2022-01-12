using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class Hand: IBlackJack
    {
        public List<Card> cardInitail = new List<Card>();
   
        public string name;
        private int playerHandValue = 0;

        private int nbwin = 0;
        private int nblose = 0;
        private int nbegalite = 0;

        private int nbwinOrdi = 0;
        private int nbloseOrdi = 0;
        private int nbegaliteOrdi = 0;

        public int GetNbwin { get => nbwin; set => nbwin = value; }
        public int GetNblose { get => nblose; set => nblose = value; }
        public int GetNbwinOrdi { get => nbwinOrdi; set => nbwinOrdi = value; }
        public int GetNbloseOrdi { get => nbloseOrdi; set => nbloseOrdi = value; }
        public int GetNbegalite { get => nbegalite; set => nbegalite = value; }
        public int GetNbegaliteOrdi { get => nbegaliteOrdi; set => nbegaliteOrdi = value; }

        public Hand() { }

        /* Fonction ajoute une Card */
        public void AddCard(Card card)
        {
            cardInitail.Add(card);
        }


        /* Fonction Jouer  */
        public void Jouer()
        {
            Console.Write("Enter votre  prenom: ");
            SetName(Console.ReadLine());
            Console.WriteLine($"\nSalut  et  Bienvenue {name} dans le jeu BlackJack ");
            VoirScore();
            VoirScoreOrdi();
        }
        /* Sette le nome du Joueur */
        public void SetName(string name)
        {
            this.name = name;
        }
        
        /* Fonction Voire Score du Joueur */
        public void VoirScore() 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine( "Jouer:{0} | Victoire: {1} | Defaite: {2} | Egalite: {3}       |",name, nbwin, nblose, nbegalite);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.ResetColor();
        }
        /* Fonction Voire Score du Croupier */
        public void VoirScoreOrdi()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Jouer:{0} | Victoire: {1} | Defaite: {2} | Egalite: {3}   |", "Croupier", nbwinOrdi, nbloseOrdi, nbegaliteOrdi);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.ResetColor();
        }

        /*Function Distribue les Cartes et  Afficher les cartes des jouer et du Croupier */
        public void DealCard()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Joueur:{0}", name);
            Console.ResetColor();

            foreach (Card crd in cardInitail)
            {
                crd.AfficherCard();
            }
            CountHand();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Total: {0}", playerHandValue);
            Console.ResetColor();
        }
        public void CountHand()
        {
            playerHandValue = 0;
            foreach (Card crd in cardInitail)
            {
                playerHandValue += crd.GetValue();
            }
        }
        public int PlayerHandValue()
        {
            return playerHandValue;
        }

        public void ResetHand()
        {
            cardInitail.Clear();
            playerHandValue = 0;
        }
    }
}
