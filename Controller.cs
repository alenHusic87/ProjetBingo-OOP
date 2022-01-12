using System;
using System.Collections.Generic;
using ProjetJeuPOO.Bingo;
using ProjetJeuPOO.SimiliBlackJack;
using ProjetJeuPOO.SimiliPendu;

namespace ProjetJeuPOO
{
   
    class Controller
    {
       
        Pendu pendu = new Pendu();

        static void Main(string[] args)
        {
            Controller start = new Controller();
            start.Menu();
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t1- Jeu de Bingo");
            Console.WriteLine("\t2- Jeu du Black Jack");
            Console.WriteLine("\t3- Jeu du Pendu");
            Console.WriteLine("\t4- Femer Session");
            Console.ResetColor();
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    Boulier a = new Boulier();
                    break;
                case "2":
                    BlackJackController gameBlackJack = new BlackJackController();
                    gameBlackJack.Play(); ;
                    break;
                case "3":
                    pendu.Jouer();
                    break;
                case "4":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tVeullez entre une choix  valide");
                    Console.ResetColor();
                    Menu();
                    Console.WriteLine();
                    break;
            }
        }
    }
}
