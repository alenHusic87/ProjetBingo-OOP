using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.Bingo
{
     interface IBingoBoulier
    {
		
		public abstract BingoBall getRanbomBall();
		public abstract void restartBoulier();		
		public abstract void add(BingoBall element);			
		public abstract bool isEmpty();
		public abstract int getSize();
	}
}
