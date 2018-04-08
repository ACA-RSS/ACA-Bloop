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
       // public SquareState[,] Squares { get; set; }

        public WorldObject[,] Squares { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        
        public int Stars { get; set; }

        public List<WorldObject> WorldObj { get; set; }

        public World() {
            Height = 14;
            Width = 21;

            for (int row = 0; row < Height; ++row)
            {
                for (int col = 0; col < Width; ++col)
                {
                    Squares[row, col] = null;
                }

            }

            WorldObj = new List<WorldObject>();
        }

        public void Configure(){
            throw new NotImplementedException();
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

        public override string ToString()
        {
            return string.Format("{0},{1}", Row, Column);
        }
    }
}
