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
            this.chosenGesture = "";
            this.gestureToRemove = "";
        }

        public void SetTheChosenGesture(string aGesture)
        {
            this.chosenGesture = aGesture;
        }

        public string GetTheChosenGesture()
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
    }
}
