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
            Console.WriteLine("Enter the 'no bots' for human v human, or 'bots' for human v artificial intelligence:");
            string answer = Console.ReadLine();
            BotsNoBotsChoice(answer);
        }

        /// <summary>
        /// A simple helper method to allow a user to choose whether they 
        /// want to go up against a friend or the computer.
        /// </summary>
        /// 
        /// <param name="answer">The answer coming in from RunGame()</param>
        private void BotsNoBotsChoice(string answer)
        {
            switch (answer.ToLower())
            {
                case "no bots":
                    Console.WriteLine("This is the human v human gameplay.");
                    break;
                case "bots":
                    Console.WriteLine("This is the human v bot gameplay");
                    break;
                default:
                    Console.WriteLine("That's not an option. Try again!");
                    Console.WriteLine("Enter the 'no bots' for human v human, or 'bot' for human v artificial intelligence:");
                    string newAnswer = Console.ReadLine();
                    BotsNoBotsChoice(newAnswer);
                    break;
            }
        }
    }
}
