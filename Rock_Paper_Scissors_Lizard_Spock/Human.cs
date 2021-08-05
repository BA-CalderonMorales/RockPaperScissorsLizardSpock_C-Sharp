using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Lizard_Spock
{
    class Human : Player
    {

        // Member variables
        string nickname;
        int lives;
        bool isItMyTurn;

        public Human(string name)
        {
            this.nickname = name;
            this.lives = 3;
            this.isItMyTurn = false;
        }

        public override void LoseLife()
        {
            this.lives -= 1;
        }

        public override void MyTurn()
        {
            this.isItMyTurn = !isItMyTurn;
        }
    }
}
