using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Lizard_Spock
{
    public abstract class Player
    {

        // Constructor
        protected Player()
        {
            // Will be overriden in Child classes.
        }

        // Member methods
        public abstract void LoseLife();

        public abstract void MyTurn();

    }
}
