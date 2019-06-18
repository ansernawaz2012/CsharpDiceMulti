using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Dice
{
    public class Game
    {
        private bool gameEnded = false;
        private string userInstruction;
        Player playerOne = new Player();
       // Score score = new Score();

        //Constructor starts game
        public Game()
        {
            StartGame(playerOne);
        }

        /// <summary>
        /// creates new instance of a player and starts loop
        /// </summary>
        public void StartGame(Player currentPlayer)
        {

            Console.WriteLine($"{currentPlayer.Name} press the return key to roll the dice.");

            Console.ReadKey();


            // Loop until score >= 20 or a 1 is rolled
            while (!gameEnded)
            {

                int currentRoll = Dice.Roll();

                Console.WriteLine($"You have rolled a {currentRoll}");

                currentPlayer = Score.CheckDiceScore(currentPlayer, currentRoll);



                if (currentPlayer.GameLost)
                {
                    EndOfGame(currentPlayer);
                }
                else if (currentPlayer.GameWon)
                {
                    EndOfGame(currentPlayer);
                }

                else
                {
                    Console.WriteLine($"Your current score is {currentPlayer.Score}");
                    Console.WriteLine("Press the return key to roll again.");

                    Console.ReadLine();
                }

            }
            
        }

        /// <summary>
        /// Allow user to start a new game
        /// </summary>
        /// <param name="userInstruction"></param>
        private void CheckUserInput(Player currentPlayer, string userInstruction)
        {
            if (userInstruction == "r")
            {
                RestartGame(currentPlayer);
            }
            else if (userInstruction == "q")
            {
                return;
            }

        }
        /// <summary>
        /// reset fields when restarting game
        /// </summary>
        public void RestartGame(Player currentPlayer)
        {
            currentPlayer.Score = 0;
            currentPlayer.GameWon = false;
            currentPlayer.GameLost = false;
            gameEnded = false;
            StartGame(currentPlayer);
        }

        /// <summary>
        /// Check how game has ended and display message accordingly
        /// </summary>
        private void EndOfGame(Player currentPlayer)
        {
            if (currentPlayer.GameWon)
            {
                Console.WriteLine($"You have won!!!! Your score is {currentPlayer.Score}");
            }
            else
            {
                Console.WriteLine($"Game Over! Your score is {currentPlayer.Score}");
            }
            // Set game ended flag to true to exit while loop
            gameEnded = true;

            Console.WriteLine("Press r to Restart or q to Quit");


            while (true)
            {

                userInstruction = Console.ReadLine().ToLower().Trim();

                if (string.IsNullOrWhiteSpace(userInstruction) || userInstruction !="r" && userInstruction !="q")
                    Console.WriteLine("You must enter r or q");
                else break;
            }


            CheckUserInput(currentPlayer, userInstruction);
        }
    }
}
