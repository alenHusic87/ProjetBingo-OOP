using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliPendu
{


    class Joueur
    {
        private string name;
        private int nbpointJoueur = 0;
        private int nbpointOrdi = 0;
        public int NbpointJoueur { get => nbpointJoueur; set => nbpointJoueur = value; }
        public int NbpointOrdi { get => nbpointOrdi; set => nbpointOrdi = value; }
        public string GetName { get => name; set => name = value; }

        public Joueur() { }
        public void SetName(string name) { this.name = name; }

        public void Jouer()
        {
            Console.Write("Enter votre  prenom: ");
            SetName(Console.ReadLine());
            Console.WriteLine($"\nSalut  et  Bienvenue {name} dans le jeu Pendu ");
            VoirScore();
            VoirScoreOrdi();
        }
        public void VoirScore()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("------------------------");
            Console.WriteLine("Jouer:{0} | Points: {1} |", name, nbpointJoueur);
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.ResetColor();
        }
        public void VoirScoreOrdi()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("------------------------");
            Console.WriteLine("Jouer:{0} | Points: {1} |", "Ordi", nbpointOrdi);
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.ResetColor();
        }


    }
}
