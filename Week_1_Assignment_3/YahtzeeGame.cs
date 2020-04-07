using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class YahtzeeGame
    {
        Dice[] dice = new Dice[5];
        public void Init()
        {
            for(int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Dice();
            }
        }

        public void Throw()
        {

            foreach(Dice d in dice)
            {
                d.Throw();
            }
        }

        public void DisplayValues()
        {
            foreach (Dice d in dice)
            {
                d.DisplayValue();
            }
        }

        public bool Yahtzee()
        {
            bool yahtzee = false;
            int last = 0;

            for(int i =0; i < dice.Length; i++)
            {
                if (i == 0)
                {
                    last = dice[i].value;
                }
                else if (last == dice[i].value)
                {
                    yahtzee = true;
                }
                else
                {
                    yahtzee = false;
                    break;
                }

            }

            return yahtzee;
        }
    }
}
