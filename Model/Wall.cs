using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wall : WorldObject
    {
        public Wall()
        {
            Type = "Wall";
            Image = "/tree.png";
        }

        //Used for building walls instead of coding each one individually
        //Takes 4 parameters: The row of the first location, and the column, the length of the wall, and 
        //Whether it's horizontal or vertical.
        //It builds a wall in the starting location (so don't accidentally make two walls in the same 
        //place), then builds a wall in each location for the number of spaces given, either moving RIGHT if
        // Horizontal ("Horz"), or DOWN if vertical ("vert"), and adds each wall piece to the World Objects list
        public static void WallBuilder(int startRow, int startCol, int numSpaces, string dir)
        {
            if (dir == "Vert")
            {
                for (int i = 0; i < numSpaces + 1; i++)
                {
                    Wall wally = new Wall() { Spot = new Location() { Row = startRow + i, Column = startCol } };
                    GameController.Instance.Level.WorldObj.Add(wally);
                }
            }
            else if (dir == "Horz")
            {
                for (int i = 0; i < numSpaces + 1; i++)
                {
                    Wall wally = new Wall() { Spot = new Location() { Row = startRow, Column = startCol + i } };

                    GameController.Instance.Level.WorldObj.Add(wally);
                }
            }

        }

        public override WorldObject Deserialize(string statsStr)
        {
            string[] stats = statsStr.Split(',');
            Wall walle = new Wall();
            walle.Spot = new Location(string.Format("{0},{1}", stats[1], stats[2]));
            return walle;
        }

        public override string Serialize()
        {
            return string.Format("Wall,{0}", Spot);
        }


        public static void LevelTwo(int quadrant)
        {
            int addRight = 0;
            int addDown = 0;

            if (quadrant == 1)
            {
                addRight = 0;
                addDown = 0;
            }
            else if (quadrant == 2)
            {
                addRight = 16;
                addDown = 0;
            }
            else if (quadrant == 3)
            {
                addRight = 0;
                addDown = 12;
            }
            else if (quadrant == 4)
            {
                addRight = 16;
                addDown = 12;
            }

            Wall.WallBuilder(3 + addDown, 0 + addRight, 7, "Vert");
            Wall.WallBuilder(7 + addDown, 1 + addRight, 3, "Vert");
            Wall.WallBuilder(4 + addDown, 2 + addRight, 1, "Vert");
            Wall.WallBuilder(7 + addDown, 3 + addRight, 3, "Vert");
            Wall.WallBuilder(7 + addDown, 3 + addRight, 3, "Vert");
            Wall.WallBuilder(5 + addDown, 5 + addRight, 4, "Vert");
            Wall.WallBuilder(8 + addDown, 6 + addRight, 1, "Vert");
            Wall.WallBuilder(2 + addDown, 7 + addRight, 1, "Vert");
            Wall.WallBuilder(7 + addDown, 7 + addRight, 1, "Vert");
            Wall.WallBuilder(7 + addDown, 8 + addRight, 3, "Vert");
            Wall.WallBuilder(1 + addDown, 9 + addRight, 2, "Vert");
            Wall.WallBuilder(4 + addDown, 13 + addRight, 1, "Vert");
            Wall.WallBuilder(3 + addDown, 15 + addRight, 7, "Vert");
            Wall.WallBuilder(1 + addDown, 3 + addRight, 4, "Vert");

            //Horizontals of top left quadrant

            Wall.WallBuilder(0 + addDown, 0 + addRight, 13, "Horz");
            Wall.WallBuilder(1 + addDown, 5 + addRight, 2, "Horz");
            Wall.WallBuilder(2 + addDown, 0 + addRight, 1, "Horz");
            Wall.WallBuilder(2 + addDown, 11 + addRight, 4, "Horz");
            Wall.WallBuilder(3 + addDown, 4 + addRight, 1, "Horz");
            Wall.WallBuilder(4 + addDown, 9 + addRight, 3, "Horz");
            Wall.WallBuilder(5 + addDown, 6 + addRight, 1, "Horz");
            Wall.WallBuilder(6 + addDown, 9 + addRight, 1, "Horz");
            Wall.WallBuilder(7 + addDown, 9 + addRight, 1, "Horz");
            Wall.WallBuilder(7 + addDown, 12 + addRight, 2, "Horz");
            Wall.WallBuilder(8 + addDown, 12 + addRight, 2, "Horz");
            Wall.WallBuilder(9 + addDown, 10 + addRight, 4, "Horz");
            Wall.WallBuilder(11 + addDown, 3 + addRight, 8, "Horz");
            Wall.WallBuilder(0 + addDown, 0 + addRight, 1, "Horz");
            Wall.WallBuilder(10 + addDown, 13 + addRight, 1, "Horz");
        }
    }

}
