using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Classe représentant un objet carte pour le joueur.
// Un joueur a au minimum une carte.

namespace ProjetJeuPOO.Bingo
{
    class BingoCard
    {
       
        private  List<int> allNumbers = new List<int>();
        private int chosenIndex;
        public BingoCard() { }

        private  Random random = new Random();

        public  List<int> AllNumbers { get => allNumbers; set => allNumbers = value; }
        public int ChosenIndex { get => chosenIndex; set => chosenIndex = value; }

        public  void RemplirBingoBoard(int[,] table)
        {
            for (int col = 0; col < table.GetLength(0); col++)
            {
                // générer tous les numéros de boule de bingo possibles pour cette colonne
                allNumbers = Enumerable.Range(1 + (col * 15), 15).ToList();

                //placez aléatoirement ces nombres dans les lignes de cette colonne
                for (var row = 0; row < table.GetLength(1); row++)
                {
                    chosenIndex = random.Next(allNumbers.Count);
                    table[row, col] = allNumbers[chosenIndex];
                    allNumbers.RemoveAt(chosenIndex);
                   
                }
            }
        }

        public  void PrintBoard(int[,] table)
        {
            // Aficcher le titre
            string[] headings = { "B", "I", "N", "G", "O" };
            for (int i = 0; i < headings.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(headings[i]+"\t");
                Console.ResetColor();
            }
            Console.WriteLine();

            //Afficher les numeros
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    //le Mileiu toujours Gratui
                    if (i == 2 & j == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        table[2, 2] = 0;
                        Console.Write("♠♠ \t");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(table[i, j] + "\t");
                        Console.ResetColor();

                    }
                }
                Console.WriteLine();
            }
        }
        public void RemplirNumeros(int[,] table, int valeur, int row)
        {
            List<int> listeNumeros = new List<int>();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (table[i, row] == 0)
                {
                    table[i, row] = valeur;
                    break;
                }
            }
            for (int i = 0; i < table.GetLength(0); i++)
            {
                listeNumeros.Add(table[i, row]);

            }
            listeNumeros.Reverse();
            listeNumeros.Sort();

            for (int i = 0; i < listeNumeros.Count; i++)
            {
                table[i, row] = listeNumeros[i];
            }
        }

        //Aficher le Tableu de Annonceur avec tout le numero qui sont tire 
        public void AfficheAnnonceur(int[,] values)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("B\tI\tN\tG\tO");
            Console.ResetColor();


            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(values[i, j] + "\t");
                    Console.ResetColor();
                }
                Console.Write("\n");
            }

        }
    }
}
