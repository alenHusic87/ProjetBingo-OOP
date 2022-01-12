using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Threading;


// Classe qui représente le boulier. On y retire les boules au hazard.

namespace ProjetJeuPOO.Bingo
{
    class Boulier : IBingoBoulier
    {


   
        private int BingoCardAmount = 0;
        private int m_match = 0;
        private Random m_random = new Random();

        

        public List<BingoCard> list_bingoCard = new List<BingoCard>();
  


       public List<BingoBall> list_balls = new List<BingoBall>();
       private int[] m_numeroRandom = new int[75];

        int[,] m_arrCard = new int[5, 5];
        int[,] m_arrCard_vide = new int[5, 5];

        private int[,] bingo_cards_vide = new int[15, 5];
        private static  List<int> bingo_numeros = new List<int>();


        private static List<int> test = new List<int>();
        private   BingoBall bingoball = new BingoBall(bingo_numeros);



        private BingoCard bingoCard = new BingoCard();
        private int[,] cards = new int[5, 5];

        public Boulier()
        {
            add(bingoball);
            getSize();
            NombreMatch();
            AfficherMenu();

        }
        private void NombreMatch()
        {
            AficherBalls();
            Console.WriteLine("                                                 ");


            VerifiMatchs(m_arrCard);
            Console.WriteLine("**********************************");
            Console.WriteLine("Vous avez obtenu les " + m_match + " numéros suivants:  ");
            Console.WriteLine("********************************************");
        }
        public int[,] VerifiMatchs(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    foreach (int number in bingo_numeros  )
                    {

                        if (number.Equals(table[i, j]))
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(table[i, j]);
                            table[i, j] = 0;
                            Console.ResetColor();
                            m_match++;

                        }

                    }
                }
            }
            bingoCard.AfficherCard(table);
            return table;
        }
        public void  AficherBalls()
        {
            foreach (var number in bingo_numeros)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(number+" ");
                AjouterLeNumerosDnasTableu(bingo_cards_vide, number);
                System.Threading.Thread.Sleep(1000);
                Console.ResetColor();
            }

        }

         //Ajouter tout le numero dans le tableu ceux qui sont tire 
        public void AjouterLeNumerosDnasTableu(int[,] table, int valeur)
        {
            if (valeur <= 15)
            {
                bingoCard.RemplirNumeros(table, valeur, 0);
            }
            else if (valeur <= 30)
            {
                bingoCard.RemplirNumeros(table, valeur, 1);
            }
            else if (valeur <= 45)
            {
                bingoCard.RemplirNumeros(table, valeur,2);
            }
            else if (valeur <= 60)
            {
                bingoCard.RemplirNumeros(table, valeur, 3);
            }
            else
            {
                bingoCard.RemplirNumeros(table, valeur, 4);
            }
        }
        public BingoBall getRanbomBall()
        {
            bingo_numeros = Enumerable.Range(1, 75).OrderBy(x => m_random.Next()).Take(75).ToList();
            bingoball = new BingoBall(bingo_numeros);
           
            return bingoball;
        }
        public void restartBoulier() 
        {
            bool playGame = false;
            while (!playGame)
            {
                Console.WriteLine("");
                Console.WriteLine("retourner au menu pour choisir un autre jeu ou de démarrer une nouvelle partie?");
                Console.WriteLine("1- Demarrer une nouvelle partie");
                Console.WriteLine("2- Retourner au menu principal");
                string response = Console.ReadLine().ToString();
                if (response.Equals("1" ))
                {
                    playGame = true;
                }
                if (response.Equals("2"))
                {
                    playGame = false;
                    Controller start = new Controller();
                    start.Menu();
                }
                else
                {
                    Console.WriteLine("Tapez 1 ou 2!");
                }
            }


        }
        public void add(BingoBall element)
        {
            ;
            list_balls.Add(getRanbomBall());
        }
        public bool isEmpty()
        {
            return true;
        }
        public int getSize()
        {
            VerifiSiCePosible();
            for (int i = 0; i < BingoCardAmount; i++)
            {
                bingoCard.RemplirBingoBoard(m_arrCard);
                bingoCard.AfficherCard(m_arrCard);
            }
            return BingoCardAmount;
        }

        public void AfficherMenu()
        {
            Console.WriteLine("1-Initialiser une nouvelle partie");
            Console.WriteLine("2-Visualiser une des cartes du joueur");
            Console.WriteLine("3-Visualiser la carte de l’annonceur");
            Console.WriteLine("4-Tirez une boule");
            Console.WriteLine("5- Fin de partie");

            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    restartBoulier();
                    break;



                case "2":;




                    break;
                case "3":
                    bingoCard.AfficheAnnonceur(bingo_cards_vide);
                    break;
                case "4":
                    add(bingoball);
                    AficherBalls();
                    NombreMatch();
                    break;
                case "5":
                    break;
                default:
                    PrintMessage("Opération invalide", false);
                    AfficherMenu();
                    break;
            }

        }
   
        /*Uils Non naisaisare*/
        public void PrintMessage(string msg, bool success)
        {
            if (success)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public int VerifiSiCePosible()
        {
             BingoCardAmount = 0;
            bool result = false;

            while (!result || BingoCardAmount < 0 || BingoCardAmount > 4)
            {
                Console.WriteLine();
                Console.WriteLine("Combien de Bingo Cards vous voulez ");
                result = Int32.TryParse(Console.ReadLine(), out BingoCardAmount);
                if (!result)
                {
                    Console.WriteLine("Entrer seulement des chiffres");
                }

                if (BingoCardAmount.Equals(0))
                {
                    Console.WriteLine("Le montant ne peut pas être 0.");
                }

            }
            return BingoCardAmount;
        }
    }
}
