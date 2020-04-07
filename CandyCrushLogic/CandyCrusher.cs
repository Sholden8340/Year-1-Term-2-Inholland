using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrushLogic
{
    public class CandyCrusher
    {
        public static bool ScoreRowPresent(RegularCandies[,] field)
        {

            for (int x = 0; x < field.GetLength(0); x++)
            {
                RegularCandies last = field[x, 0];
                int count = 1;

                for (int y = 1; y < field.GetLength(1); y++)
                {
                    if (field[x, y] == last && x != 0 && y != 0)
                    {
                        count++;
                        if (count == 3)
                            return true;
                    }
                    else
                    {
                        count = 1;
                    }
                    last = field[x, y];
                }
            }
            return false;
        }

        public static bool ScoreColumnPresent(RegularCandies[,] field)
        {

            for (int y = 0; y < field.GetLength(1); y++)
            {
                RegularCandies last = field[0, y];
                int count = 1;

                for (int x = 1; x < field.GetLength(0); x++)
                {

                    if (field[x, y] == last && x != 0)
                    {
                        count++;
                        if (count == 3)
                            return true;
                    }
                    else
                    {
                        count = 1;
                    }
                    last = field[x, y];
                }
            }
            return false;
        }
    }
}
