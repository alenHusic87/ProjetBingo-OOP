using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class BlackJackController
    {
      
        private Deck deck = new Deck();
        private Hand joueur = new Hand();
        private Hand croupier = new Hand();

        private int cardPosistion = 0;
        private bool stand = false;
        private bool bust = false;




        public BlackJackController()
        {
           joueur.Jouer();
           croupier.SetName("Croupier");

        }
        private void GameStart()
        {
            joueur.AddCard(deck.GetCard(cardPosistion));
            joueur.AddCard(deck.GetCard(cardPosistion + 1));
            cardPosistion += 2;

            croupier.AddCard(deck.GetCard(cardPosistion));
            croupier.AddCard(deck.GetCard(cardPosistion + 1));
            cardPosistion += 2;

            joueur.DealCard();
            Console.WriteLine();
            croupier.DealCard();

        }
        public void Play()
        {
            stand = false;
            bust = false;
            cardPosistion = 0;
            deck.Shuffle();

            joueur.ResetHand();
            croupier.ResetHand();

            GameStart();

            while (stand == false)
            {
                JoueurDecision();
                IsJouerBusted();
            }

            if (bust == false)
            {
                CroupierTurn();
                VerifieVictoire();
            }
            
            AnotherRound();
        }
        private void CroupierTurn()
        {
            int counter = 0;
            croupier.CountHand();

            if (joueur.PlayerHandValue() <= 21 && croupier.PlayerHandValue() <= 20)
            {
                while (croupier.PlayerHandValue() < joueur.PlayerHandValue())
                {
                    croupier.AddCard(deck.GetCard(cardPosistion));
                    cardPosistion++;
                    counter++;
                    croupier.CountHand();
                }
            }
            Console.WriteLine("Le Croupier a prit {0} carte\n", counter);

            joueur.DealCard();
            Console.WriteLine();
            croupier.DealCard();
        }
        private void AnotherRound()
        {
            while (joueur.GetNbwin <= 3 && joueur.GetNblose <=3)
            {
                joueur.VoirScore();
                croupier.VoirScoreOrdi();
                Play();

                if (joueur.GetNblose == 4)
                {
                    Console.Write("\nLe Croupier  a gagner le tournois");
                    Rejouer();
                }
                if (joueur.GetNbwin==4)
                {
                    Console.Write( " \n  Joueur a gagner le tournois");
                    Rejouer();
                }
            }



        }
        private void Rejouer() 
        {
            bool playGame = false;
            while (!playGame)
            {
                Console.WriteLine("");
                Console.Write("Voulez-vous jouer encore (Oui/Non) ? ");
                string response = Console.ReadLine().ToString().ToUpper();
                if (response == "Oui" || response == "O")
                {
                    playGame = true;
                    joueur.ResetHand();
                    croupier.ResetHand();
                    joueur.GetNbegalite = 0;
                    joueur.GetNblose= 0;
                    joueur.GetNbwin = 0;

                    croupier.GetNbegaliteOrdi = 0;
                    croupier.GetNbloseOrdi = 0;
                    croupier.GetNbwinOrdi = 0;
                    GameStart();

                }
                if (response == "Non" || response == "N")
                {
                    playGame = false;
                    Controller start = new Controller();
                    start.Menu();
                }
                else
                {
                    Console.WriteLine("Tapez Oui ou Non!");
                }
            }

        }
        private void VerifieVictoire()
        {
            joueur.CountHand();
            croupier.CountHand();

            if (joueur.PlayerHandValue().Equals(21))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(joueur.name + ": {0}\tCroupier: {1}  " + joueur.name + " a gagner ", joueur.PlayerHandValue(), croupier.PlayerHandValue());
                Console.ResetColor();
                joueur.GetNbwin++;
                croupier.GetNbloseOrdi++;

            }
            else if (croupier.PlayerHandValue() > 21)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(joueur.name + ": {0}\tCroupier: {1}  " + joueur.name + " a gagner ", joueur.PlayerHandValue(), croupier.PlayerHandValue());
                Console.ResetColor();
               
                joueur.GetNbwin++;
                croupier.GetNbloseOrdi++; 

            }
            else if (joueur.PlayerHandValue() < croupier.PlayerHandValue())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
    
                Console.WriteLine(joueur.name + ": {0}\tCroupier: {1}\tCroupier a gagner", joueur.PlayerHandValue(), croupier.PlayerHandValue());
                Console.ResetColor();
                joueur.GetNblose++;
                croupier.GetNbwinOrdi++;

            }
            else if (joueur.PlayerHandValue() > croupier.PlayerHandValue())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(joueur.name + ": {0}\tCroupier: {1}  " +joueur.name + " a gagner  ", joueur.PlayerHandValue(), croupier.PlayerHandValue());
                Console.ResetColor();
                joueur.GetNbwin++; 
                croupier.GetNbloseOrdi++;


            }
            else if (joueur.PlayerHandValue().Equals(croupier.PlayerHandValue()))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(joueur.name + " : {0}\nCroupier: {1}\tEgalite", joueur.PlayerHandValue(), croupier.PlayerHandValue());
                Console.ResetColor();
                joueur.GetNbegalite++;
                croupier.GetNbegaliteOrdi++;
            }
        }
        /*Function verifie si le jouer a Buster*/
        private void IsJouerBusted()
        {
            joueur.CountHand();
            if (joueur.PlayerHandValue() > 21)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(joueur.name + ": {0}\tCroupier: {1}\tCroupier a gagner ", joueur.PlayerHandValue(), croupier.PlayerHandValue());
                Console.ResetColor();
                bust = true;
                stand = true;
                joueur.GetNblose++;
                croupier.GetNbwinOrdi++;
               
            }
        }
        /* Function qui demande si on veux un autre Carte*/
        private void UneAutreCarte()
        {
            joueur.AddCard(deck.GetCard(cardPosistion));
            cardPosistion++;

            joueur.DealCard();
            Console.WriteLine();
            croupier.DealCard();
        }
        // Fonction qui permet de demander une nouvelle carte ou de conserver  sa mise
        private void JoueurDecision()
        {
            string choix = "";
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Voulez-vous avoir une autre Carte ou conserver votre Mise?");
                Console.WriteLine("O- Une autre carte ?");
                Console.WriteLine("N- Conserver sa mise ?");

                choix = Console.ReadLine();
                if (choix.ToUpper() == "O")
                {
                    UneAutreCarte();
                    break;
                }
                else if (choix.ToUpper() == "N")
                {
                    stand = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Mauvaise saisie ! Essayer à nouveau!");
                    continue;
                }
            }
        }
    }


}
