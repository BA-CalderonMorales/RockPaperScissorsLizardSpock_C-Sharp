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
        List<string> gesture;
        string chosenGesture;
        string gestureToRemove;

        public Human(string name)
        {
            this.nickname = name;
            this.lives = 3;
            this.isItMyTurn = false;
            this.chosenGesture = ""; // rock, paper, scissors, lizard, spock
            this.gestureToRemove = ""; // rock, paper, scissors, lizard, spock
        }

        public override int GetRemainingLives()
        {
            return this.lives;
        }

        public override string GetTheNickname()
        {
            return this.nickname;
        }
        public override void SetTheNickName(string name)
        {
            this.nickname = name;
        }
        public void SetTheChosenGesture(string gesture)
        {
            this.chosenGesture = gesture;
        }

        public override string GetTheChosenGesture()
        {
            return this.chosenGesture;
        }

        public void SetTheGestureToRemove(string aGestureToRemove)
        {
            this.gestureToRemove = aGestureToRemove;
        }

        public string GetTheGestureToRemove()
        {
            return this.gestureToRemove;
        }

        public override void LoseLife()
        {
            this.lives -= 1;
        }

        public override void MyTurn()
        {
            this.isItMyTurn = !isItMyTurn;
        }

        public override void ChooseGesture()
        {
            this.gesture.Add(this.chosenGesture);
        }

        public override void RemoveGesture()
        {
            this.gesture.Remove(this.gestureToRemove);
        }

        public override string ToString()
        {
            return this.nickname.ToString();
        }

        public void ShowGestureOptions()
        {
            string[] all_gestures = new string[5];
            all_gestures[0] = "1. Rock";
            all_gestures[1] = "2. Paper";
            all_gestures[2] = "3. Scissors";
            all_gestures[3] = "4. Lizard";
            all_gestures[4] = "5. Spock";
            Console.WriteLine("Here are your gesture options:");
            for (int index = 0; index < all_gestures.Length; index++)
            {
                Console.WriteLine($"{all_gestures[index]}");
            }
        }
    }
}
