﻿using System;
using System.Collections.Generic;
using ProjetJeuPOO.Bingo;
using ProjetJeuPOO.SimiliBlackJack;
using ProjetJeuPOO.SimiliPendu;

namespace ProjetJeuPOO
{
   
    class Controller
    {
       
        static void Main(string[] args)
        {
           // Boulier a = new Boulier();
             BlackJackController gameBlackJack = new BlackJackController();
            gameBlackJack.Play();


        }
    }
}
