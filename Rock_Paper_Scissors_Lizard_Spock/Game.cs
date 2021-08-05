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
        /// <summary>
        /// The Game object is istantiated with no member variables.
        /// All other classes are imported via the namespace. No need
        /// to import all the classes being used to run this game.
        /// </summary>
        public Game()
        {
            // Empty Game object.
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
            Console.WriteLine($"{check}");
            do
            {
                if (check == "invalid")
                {
                    Console.WriteLine("That was an invalid choice.");
                    Console.WriteLine("Enter 'no bots' for human v human, or 'bots' for human v artificial intelligence:");
                    answer = Console.ReadLine();
                    check = BotsNoBotsChoice(answer);
                }
                else
                {
                    // Console.WriteLine("Good Job");
                }
            } while (check == "invalid");
            // Console.WriteLine($"{answer}"); no bots or bots will only pass. 
            // Console.WriteLine($"{check}"); valid is passed 
            switch (answer.ToLower()) 
            {
                case "bots":
                    // Console.WriteLine($"Currently in the {answer} gameplay");
                    Console.WriteLine("This is the human v. ai gameplay.");
                    break;

                case "no bots":
                    // Console.WriteLine($"Currently in the {answer} gameplay");
                    Console.WriteLine("This is the human v. human gameplay.");
                    break;
            }
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
    }
}