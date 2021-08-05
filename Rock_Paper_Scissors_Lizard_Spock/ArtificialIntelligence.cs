using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Lizard_Spock
{
    class ArtificialIntelligence : Player
    {
        // Member variables
        string[] botnames;
        string nickname;
        int lives;
        bool isItMyTurn;

        public ArtificialIntelligence()
        {
            this.nickname = SetBotName();
            this.lives = 3;
            this.isItMyTurn = false;
        }

        public string SetBotName()
        {
            string chosenBot = "";
            string[] bots = new string[7];
            Random random = new Random();
            int rand = random.Next(0, 7);
            bots[0] = "Mechanized Data Destruction Juggernaut";
            bots[1] = "Spanner";
            bots[3] = "Nuclear Human Control Tech Boi";
            bots[4] = "Prime War Machine";
            bots[5] = "Inoid";
            bots[6] = "Mega Man";
            for (int index = 0; index < bots.Length; index++)
            {
                if (bots[index] == bots[rand])
                {
                    chosenBot = bots[index];
                }
            }
            return chosenBot;
        }

        public override void LoseLife()
        {
            this.lives -= 1;
        }

        public override void MyTurn()
        {
            this.isItMyTurn = !isItMyTurn;
        }

        public override string ToString()
        {
            return this.nickname.ToString();
        }
    }
}
