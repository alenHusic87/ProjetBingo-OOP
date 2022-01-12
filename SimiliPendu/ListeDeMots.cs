using System;
using System.Collections.Generic;

namespace ProjetJeuPOO.SimiliPendu
{
    class ListeDeMots
    {
        private List<string> listeDeMot;

        public List<string> ListeDeMot { get => listeDeMot; set => listeDeMot = value; }

        public ListeDeMots()
        {
            this.listeDeMot = new List<string>();
        }
        public string GetRandomMot()
        {
            Random random = new Random();
            int index = random.Next(0, listeDeMot.Count);
            return listeDeMot[index];
        }
    }
}
