using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetJeuPOO.SimiliPendu
{
   // String[] listeMots = { "bateau", "chaise", "film", "taxi", "montagne", "stylo" };
    class ListeDeMots
    {
        private List<string> listeDeMot;
        // Constructeur
        public List<string> ListeDeMot
        {
            get => listeDeMot;
            set => listeDeMot = value;
        }
        // Le constructeur
        public ListeDeMots()
        {
            listeDeMot = new List<string>();
        }
        // Fonction qui permet de retourner un mot au hasard
        public string getRandomWord()
        {
            Random random = new Random();
            int index = random.Next(0, listeDeMot.Count);
            return listeDeMot[index];
        }

    }
}
