using System;
using System.Text;

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
            this.firstPlayer = new Human("human");
            this.secondPlayer = new Human("human");
            this.compPlayer = new ArtificialIntelligence();
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
                    // Gather nicknames for each player.
                    Console.WriteLine("Choose a nickname:");
                    string nickname = Console.ReadLine();

                    this.firstPlayer.SetTheNickName(nickname);
                    this.compPlayer.SetBotName();

                    Console.WriteLine($"{this.firstPlayer.GetTheNickname()}, you're up against: {this.compPlayer.GetTheNickname()}");

                    // Start of Game Logic
                    while (this.firstPlayer.GetRemainingLives() >= 2 && this.compPlayer.GetRemainingLives() > 0
                        || this.firstPlayer.GetRemainingLives() > 0 && this.compPlayer.GetRemainingLives() >= 2)
                    {

                        string[] choices = GetAllChoices();

                        Console.WriteLine($"{this.firstPlayer.GetTheNickname()}, choose a gesture:");
                        string responseOne = RetrieveAnswer(choices);

                        this.compPlayer.ChooseGesture();

                        AssignGestureSinglePlayer(responseOne);

                        string playerOneGesture = this.firstPlayer.GetTheChosenGesture();
                        string compGesture = this.compPlayer.GetTheChosenGesture();

                        RetrieveRoundResult(playerOneGesture, compGesture);
                        Console.WriteLine($"{this.firstPlayer.GetRemainingLives()}");
                        Console.WriteLine($"{this.compPlayer.GetRemainingLives()}");
                        if (this.firstPlayer.GetRemainingLives() == 1 && this.compPlayer.GetRemainingLives() >= 2)
                        {
                            this.firstPlayer.LoseLife();
                            Console.WriteLine($"Looks like {this.compPlayer.GetTheNickname()} won!");
                            Console.WriteLine("Run the program to play again. Hit enter to end this game session.");
                        }
                        else if (this.compPlayer.GetRemainingLives() == 1 && this.firstPlayer.GetRemainingLives() >= 2)
                        {
                            this.compPlayer.LoseLife();
                            Console.WriteLine($"Looks like {this.firstPlayer.GetTheNickname()} won!");
                            Console.WriteLine("Run the program to play again. Hit enter to end this game session.");
                        }
                    }
                    break;

                case "no bots":
                    // Gather nicknames for each player.
                    Console.WriteLine("This is the human v. human gameplay.");
                    Console.WriteLine("Player one, choose a nickname:");
                    string humanOne = Console.ReadLine();
                    Console.WriteLine("Player two, choose a nickname:");
                    string humanTwo = Console.ReadLine();

                    this.firstPlayer.SetTheNickName(humanOne);
                    this.secondPlayer.SetTheNickName(humanTwo);

                    // Start of Game Logic
                    while (this.firstPlayer.GetRemainingLives() >= 2 && this.secondPlayer.GetRemainingLives() > 0
                        || this.firstPlayer.GetRemainingLives() > 0 && this.secondPlayer.GetRemainingLives() >= 2)
                    {

                        string[] choices = GetAllChoices();

                        Console.WriteLine($"{this.firstPlayer.GetTheNickname()}, choose a gesture:");
                        string responseOne = RetrieveAnswer(choices);
                        
                        Console.WriteLine($"{this.secondPlayer.GetTheNickname()}, choose a gesture:");
                        string responseTwo = RetrieveAnswer(choices);

                        AssignGesturesMultiplayer(responseOne, responseTwo);

                        string playerOneGesture = this.firstPlayer.GetTheChosenGesture();
                        string playerTwoGesture = this.secondPlayer.GetTheChosenGesture();

                        RetrieveRoundResult(playerOneGesture, playerTwoGesture);
                        Console.WriteLine($"{this.firstPlayer.GetRemainingLives()}");
                        Console.WriteLine($"{this.secondPlayer.GetRemainingLives()}");
                        if (this.firstPlayer.GetRemainingLives() == 1 && this.secondPlayer.GetRemainingLives() >= 2)
                        {
                            this.firstPlayer.LoseLife();
                            Console.WriteLine($"Looks like {this.secondPlayer.GetTheNickname()} won!");
                            Console.WriteLine("Run the program to play again. Hit enter to end this game session.");
                        }
                        else if (this.secondPlayer.GetRemainingLives() == 1 && this.firstPlayer.GetRemainingLives() >= 2)
                        {
                            this.secondPlayer.LoseLife();
                            Console.WriteLine($"Looks like {this.firstPlayer.GetTheNickname()} won!");
                            Console.WriteLine("Run the program to play again. Hit enter to end this game session.");
                        }
                    }
                    break;
            }
        }
        private string GetHiddenConsoleInput()
        {
            string response = null;
            Console.WriteLine("Please enter a choice and then press <Enter> to submit. If you choose something wonky, you will default to rock.");
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                response += key.KeyChar;
            }
            // Console.WriteLine($"{response}"); Simply returns the string version of 1, 2, 3, 4, or 5.
            return response;
        }
        
        private string RetrieveAnswer(string[] choices)
        {
            string response = ""; // Holds what is returned
            this.firstPlayer.ShowGestureOptions(); // Options displayed to the players
            string chosenNumber = GetHiddenConsoleInput(); // Hides the input from the players
            for (int index = 0; index < choices.Length; index++)
            {
                if (chosenNumber == "1")
                {
                    response = choices[0]; // rock
                }
                else if (chosenNumber == "2")
                {
                    response = choices[1]; // paper
                }
                else if (chosenNumber == "3")
                {
                    response = choices[2]; // scissors
                }
                else if (chosenNumber == "4")
                {
                    response = choices[3]; // lizard
                }
                else if (chosenNumber == "5")
                {
                    response = choices[4]; // spock
                }
                else
                {
                    // defaults to 0, if you want to pick anything other than 1-5
                    // which is rock.
                    response = choices[0]; 
                }
            }
            return response; // returns 1, 2, 3, 4, or 5...
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

        private void AssignGestureSinglePlayer(string playerGesture)
        {
            // 1 = rock, 2 = paper, 3 = scissors, 4 = lizard, 5 = spock
            string handOne = playerGesture;

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
        }

        private void AssignGesturesMultiplayer(string playerOneGesture, string playerTwoGesture)
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
            // Console.WriteLine($"{this.firstPlayer.GetTheChosenGesture()} {this.secondPlayer.GetTheChosenGesture()}");
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
            else
            {
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
    }
}