using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public static class Score
    {
        /// <summary>
        /// Sets game lost flag if 1 is rolled.
        /// Updates player score with dice roll.
        /// Sets game won flag if score >= 20. 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="diceScore"></param>
        /// <returns></returns>
        public static Player CheckDiceScore(Player player, int diceScore)
        {

            // End game as soon as 1 is rolled without updating score
            if (diceScore == 1)
            {
                player.GameLost = true;
                return player;
            }

            player.Score += diceScore;

            // End game if player score reaches 20 or more
            if (player.Score >= 20)
            {
                player.GameWon = true;
            }
            

            return player;
        }


    }
}
