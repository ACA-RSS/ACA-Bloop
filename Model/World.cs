using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{

    public enum SquareState { Animal, Grass, House, Scotty, Star, Stick, Stump, Wall  };

    public class World
    {
        public SquareState[,] Squares { get; set; }
        public int Size { get; set; }
        public int Difficulty { get; set; }

        public World() {
            Size = 200;

            for (int row = 0; row < Size; ++row)
            {
                for (int col = 0; col < Size; ++col)
                {
                    Squares[row, col] = SquareState.Grass;
                }

            }
        }

        public void Configure(){
            throw NotImplementedError();
        }

    }

    public struct Location
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Location(string rowColStr)
        {
            string[] rowCol = rowColStr.Split(',');
            Row = int.Parse(rowCol[0]);
            Column = int.Parse(rowCol[1]);
        }
    }
}
