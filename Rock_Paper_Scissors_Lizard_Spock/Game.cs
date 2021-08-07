using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Lizard_Spock
{
    /// <summary>
    /// This Game class is used to produce Game objects whose method
    /// RunGame() is meant to allow it to actually run whenever it is
    /// called inside of the Program.cs file, inside of
    /// the static void Main(string[] args) method.
    /// </summary>
    class Game
    {
        // Member Variables
        Human firstPlayer;
        Human secondPlayer;
        ArtificialIntelligence compPlayer;

        /// <summary>
        /// All other classes are imported via the namespace. No need
        /// to import all the classes being used to run this game.
        /// </summary>
        public Game()
        {
            // Empty
        }

        /// <summary>
        /// This method is used to allow the Game object that is 
        /// instantiated to call RunGame in order to allow the
        /// logic inside of Game to occur. Works in conjunction
        /// with Human.cs, ArtificialIntelligence.cs, and Player.cs.
        /// </summary>
        public void RunGame()
        {
            Console.WriteLine("Welcome to Rock, Paper, Lizard, Spock!");
            Console.WriteLine("Are you going to go up against buddy, or would you like to go against the computer?");
            Console.WriteLine("Enter 'no bots' for human v human, or 'bots' for human v artificial intelligence:");
            string answer = Console.ReadLine();
            string check = BotsNoBotsChoice(answer);
            
            do
            {
                if (check == "invalid")
                {
                    Console.WriteLine("That was an invalid choice.");
                    Console.WriteLine("Enter 'no bots' for human v human, or 'bots' for human v artificial intelligence:");
                    answer = Console.ReadLine();
                    check = BotsNoBotsChoice(answer);
                }
            } while (check == "invalid");
            
            switch (answer.ToLower())
            {
                case "bots":
                    Console.WriteLine("This is the human v. ai gameplay.");
                    break;

                case "no bots":
                    // Gather nicknames for each player.
                    Console.WriteLine("This is the human v. human gameplay.");
                    Console.WriteLine("Player one, choose a nickname:");
                    string nicknameOne = Console.ReadLine();
                    Console.WriteLine("Player two, choose a nickname:");
                    string nicknameTwo = Console.ReadLine();

                    this.firstPlayer.SetTheNickName(nicknameOne);
                    this.secondPlayer.SetTheNickName(nicknameTwo);

                    // Start of Game Logic
                    do
                    {
                        
                        string[] choices = GetAllChoices();

                        Console.WriteLine($"{this.firstPlayer.GetTheNickname()}, choose a gesture:");
                        string responseOne = RetrieveAnswer(choices, this.firstPlayer);
                        Console.WriteLine($"{this.secondPlayer.GetTheNickname()}, choose a gesture:");
                        string responseTwo = RetrieveAnswer(choices, this.secondPlayer);

                        AssignGestures(responseOne, responseTwo);

                        string playerOneGesture = this.firstPlayer.GetTheChosenGesture();
                        string playerTwoGesture = this.secondPlayer.GetTheChosenGesture();

                        RetrieveRoundResult(playerOneGesture, playerTwoGesture);

                    } while (this.firstPlayer.GetRemainingLives() > 0 && this.secondPlayer.GetRemainingLives() > 0);
                        break;
            }
        }

        private void RetrieveRoundResult(string handOne, string handTwo)
        {
            string tie = handOne + " " + handTwo;
            bool check = false;
            switch (tie)
            {
                case "rock rock":
                case "paper paper":
                case "scissors scissors":
                case "lizard lizard":
                case "spock spock":
                    check = true;
                    break;
            }
            if (!check)
            {
                NotATie(handOne, handTwo);
            }
        }

        private void NotATie(string handOne, string handTwo)
        {
            switch (handOne)
            {
                case "rock":
                    switch (handTwo)
                    {
                        case "paper":
                            // rock is covered by paper
                            this.firstPlayer.LoseLife();
                            break;
                        case "spock":
                            // rock is vaporized by spock
                            this.firstPlayer.LoseLife();
                            break;
                        case "lizard":
                            // rock crushes lizard
                            this.secondPlayer.LoseLife();
                            break;
                        case "scissors":
                            // rock crushes scissors
                            this.secondPlayer.LoseLife();
                            break;
                    }
                    break;
                
                case "paper":
                    switch (handTwo) 
                    {
                        case "lizard":
                            // paper is eaten by lizard
                            this.firstPlayer.LoseLife();
                            break;
                        case "scissors":
                            // paper is cut by scissors
                            this.firstPlayer.LoseLife();
                            break;
                        case "spock":
                            // paper disproves spock
                            this.secondPlayer.LoseLife();
                            break;
                        case "rock":
                            // paper covers rock
                            this.secondPlayer.LoseLife();
                            break;
                    }
                    break;
                
                case "scissors":
                    switch (handTwo)
                    {
                        case "rock":
                            // scissors is crushed by rock
                            this.firstPlayer.LoseLife();
                            break;
                        case "spock":
                            // paper disproves spock
                            this.firstPlayer.LoseLife();
                            break;
                        case "lizard":
                            // scissors decapitates lizard
                            this.secondPlayer.LoseLife();
                            break;
                        case "paper":
                            // scissors cuts paper
                            this.secondPlayer.LoseLife();
                            break;
                    }
                    break;
                
                case "lizard":
                    switch (handTwo)
                    {
                        case "rock":
                            // lizard is crushed by rock
                            this.firstPlayer.LoseLife();
                            break;
                        case "spock":
                            // lizard poisons spock
                            this.secondPlayer.LoseLife();
                            break;
                        case "paper":
                            // lizard eats paper
                            this.secondPlayer.LoseLife();
                            break;
                        case "scissors":
                            // scissors cuts paper
                            this.firstPlayer.LoseLife();
                            break;
                    }
                    break;

                case "spock":
                    switch (handTwo)
                    {
                        case "paper":
                            // spock is dispproved by paper
                            this.firstPlayer.LoseLife();
                            break;
                        case "scissors":
                            // spock smashes scissors
                            this.firstPlayer.LoseLife();
                            break;
                        case "rock":
                            // spock vaporizes rock
                            this.secondPlayer.LoseLife();
                            break;
                        case "lizard":
                            // spock is poisoned by lizard
                            this.secondPlayer.LoseLife();
                            break;
                    }
                    break;
            }
            
        }

        private void AssignGestures(string playerOneGesture, string playerTwoGesture)
        {
            // 1 = rock, 2 = paper, 3 = scissors, 4 = lizard, 5 = spock
            string handOne = playerOneGesture;
            string handTwo = playerTwoGesture;

            switch (handOne)
            {
                case "1":
                    this.firstPlayer.SetTheChosenGesture("rock");
                    break;
                case "2":
                    this.firstPlayer.SetTheChosenGesture("paper");
                    break;
                case "3":
                    this.firstPlayer.SetTheChosenGesture("scissors");
                    break;
                case "4":
                    this.firstPlayer.SetTheChosenGesture("lizard");
                    break;
                case "5":
                    this.firstPlayer.SetTheChosenGesture("spock");
                    break;
            }
            switch (handTwo)
            {
                case "1":
                    this.secondPlayer.SetTheChosenGesture("rock");
                    break;
                case "2":
                    this.secondPlayer.SetTheChosenGesture("paper");
                    break;
                case "3":
                    this.secondPlayer.SetTheChosenGesture("scissors");
                    break;
                case "4":
                    this.secondPlayer.SetTheChosenGesture("lizard");
                    break;
                case "5":
                    this.secondPlayer.SetTheChosenGesture("spock");
                    break;
            }
        }

        private string RetrieveAnswer(string[] choices, Human player)
        {
            player.ShowGestureOptions();
            string response = "";
            Console.WriteLine("Press <Enter> when you've finished selecting your gesture:");
            StringBuilder input = new StringBuilder();
            string chosenGesture = GetHiddenConsoleInput(input);
            for (int index = 0; index < choices.Length; index++)
            {
                if (choices[index] == chosenGesture && chosenGesture == "1")
                {
                    response = choices[index];
                }
            }
            return response; // returns 1, 2, 3, 4, or 5...
        }

        /// <summary>
        /// A method to allow a user to choose whether they 
        /// want to go up against a friend or the computer.
        /// </summary>
        /// 
        /// <param name="answer">The answer coming in from RunGame()</param>
        private string BotsNoBotsChoice(string answer)
        {
            if (answer.ToLower() == "bots" || answer.ToLower() == "no bots")
            {
                return "valid";
            }
            else {
                return "invalid";
            }
        }

        private string[] GetAllChoices()
        {
            string[] choices = new string[5];
            choices[0] = "1"; // rock
            choices[1] = "2"; // paper
            choices[2] = "3"; // scissors
            choices[3] = "4"; // lizard
            choices[4] = "5"; // spock
            return choices;
        }

        private string GetHiddenConsoleInput(StringBuilder input)
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    input.Append(key.KeyChar);
                }
            }
            return input.ToString();
        }
    }
}