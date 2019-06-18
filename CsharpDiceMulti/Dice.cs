using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
   public static class Dice
    {
        public static int Roll()
        {
            Random randomNumber = new Random();



            return randomNumber.Next(1, 7);
        }
    }
}
