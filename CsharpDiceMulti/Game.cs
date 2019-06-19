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

      static  List<Player> players = new List<Player>();
      static List<Tuple<string, int>> PlayerScoresList = new List<Tuple<string, int>>();

        static int currentPlayerIndex = 0;

       // Player playerOne = new Player();
       // Score score = new Score();

        //Constructor starts game
        public Game()
        {
            CreatePlayers();

            StartGame(players[currentPlayerIndex]);
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

                Console.WriteLine($"{currentPlayer.Name} you have rolled a {currentRoll}");

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
            int activePlayer = currentPlayerIndex % players.Count;

            StartGame(players[activePlayer]);
        }

        /// <summary>
        /// Check how game has ended and display message accordingly
        /// </summary>
        private void EndOfGame(Player currentPlayer)
        {
            if (currentPlayer.GameWon)
            {
                Console.WriteLine($"You have won!!!! Your score is {currentPlayer.Score}");
                StoreResult(currentPlayer);
                Score.ShowLeaderboard(PlayerScoresList);
                currentPlayerIndex += 1;

            }
            else
            {
                Console.WriteLine($"Game Over! Your score is {currentPlayer.Score}");
                StoreResult(currentPlayer);
                Score.ShowLeaderboard(PlayerScoresList);
                currentPlayerIndex += 1;
               

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

        

        //Add result to list
        private void StoreResult(Player currentPlayer)
        {
            PlayerScoresList.Add(new Tuple<string, int>(currentPlayer.Name, currentPlayer.Score));
        }

        //function to create player objects and add to list
        public void CreatePlayers()
        {
            Console.Write("Enter the number of players: ");



            int numberOfPlayers;
            string input = Console.ReadLine();

            //Loop until valid input entered
            while (!Int32.TryParse(input, out numberOfPlayers))

            {
                Console.WriteLine("Invalid input. Please enter a number");
                input = Console.ReadLine();
            }



            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(i+1));
            }

        }
    }
}
