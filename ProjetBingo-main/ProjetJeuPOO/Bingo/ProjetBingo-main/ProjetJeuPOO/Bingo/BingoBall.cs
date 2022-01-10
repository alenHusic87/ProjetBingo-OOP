using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Classe représentant un objet boule 

namespace ProjetJeuPOO.Bingo
{
    class BingoBall
    {
        private  List<int> number_list = new List<int>();
       
 
         public BingoBall(List<int> number)
        {

            this.number_list = number;

        }

        public List<int> GetNumberBall { get => number_list; set => number_list = value; }
    }
}
