using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment_2
{
    class Dice
    {
        public int value;
        static Random rng = new Random();
        
        
        public void Throw()
        {
            value = rng.Next(1, 7);
        }

        public void DisplayValue()
        {
            Console.Write(" " + value);
        }
    }


}
