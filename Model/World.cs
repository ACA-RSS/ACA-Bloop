//Contains all code describing the World

//Contains the basic attributes needed for each level, mainly the grid of objects and basic methods
//for manipulation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class World
    {
        //Grid of WorldObjects to keep track of their locations
        public WorldObject[,] Squares { get; set; }

        //Number of rows in the world grid
        public int Height { get; set; }

        //Number of Columns in the world grid
        public int Width { get; set; }

        //Number of stars the user has collected in this level
        public int Stars { get; set; }

        //List of living World Objects contained in the level
        public List<WorldObject> WorldObj { get; set; }

        public World()
        {
            Height = 24;
            Width = 32;
            Stars = 0;

            Squares = new WorldObject[ Height, Width];

            for (int row = 0; row < Height; ++row)
            {
                for (int col = 0; col < Width; ++col)
                {
                    Squares[row, col] = null;
                }

            }

            WorldObj = new List<WorldObject>();
        }

        //resets the world to represent a new level by creating a new empty grid
        public void Reset()
        {
            for (int row = 0; row < Height; ++row)
            {
                for (int col = 0; col < Width; ++col)
                {
                    Squares[row, col] = null;
                }

            }
        }
    }

    //contains row and column coordinates
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
