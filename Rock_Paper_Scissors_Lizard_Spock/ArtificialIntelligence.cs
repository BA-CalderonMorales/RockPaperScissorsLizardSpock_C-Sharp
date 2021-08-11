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
        List<string> gestures;
        string chosenGesture; // rock, paper, scissors, lizard, spock

        public ArtificialIntelligence()
        {
            this.nickname = SetBotName();
            this.lives = 3;
            this.isItMyTurn = false;
            this.gestures = new List<string>();
            this.chosenGesture = "";
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

        public override void SetTheChosenGesture(string gesture)
        {
            this.chosenGesture = gesture;
        }

        public override void ChooseGesture()
        {
            Random random = new Random();
            int rand = random.Next(0, 5);
            string[] all_gestures = new string[5];
            all_gestures[0] = "rock";
            all_gestures[1] = "paper";
            all_gestures[2] = "scissors";
            all_gestures[3] = "lizard";
            all_gestures[4] = "spock";
            for (int index = 0; index < all_gestures.Length; index++)
            {
                if (all_gestures[index] == all_gestures[rand])
                {
                    this.chosenGesture = all_gestures[index];
                    this.gestures.Add(all_gestures[index]);
                }
            }
        }

        public override void RemoveGesture()
        {
            this.gestures.Remove(this.chosenGesture);
        }

        public override void SetTheNickName(string name)
        {
            throw new NotImplementedException();
        }

        public override string GetTheChosenGesture()
        {
            return this.chosenGesture;
        }
    }
}
