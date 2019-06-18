using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Player
    {
        //public string PlayerName = "";
        public int Score { get; set; } = 0;

        public string Name { get; set; }

        public bool GameLost { get; set; } = false;

        public bool GameWon { get; set; } = false;


        public Player()
        {

            //loop until name is entered
            while (true)
            {
                Console.WriteLine("Please enter your name:");
                Name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Name))
                    Console.WriteLine("Your entry was blank");
                else break;
            }

        }
    }
}
