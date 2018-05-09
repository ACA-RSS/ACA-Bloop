//Contains all code for the Wall class, derived from World Object

//Wall: One unit in usually a line of inpenetrable trees. The class contains methods for setting
//Up the walls of most levels

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wall : WorldObject
    {
        public int WidthMultiple { get; set; }
        public Wall()
        {
            Type = "Wall";
            Image = "/tree.png";
            WidthMultiple = 1;

        }

        //Used for building walls instead of coding each one individually
        //Takes 4 parameters: The row of the first location, and the column, the length of the wall, and 
        //Whether it's horizontal or vertical.
        //It builds a wall in the starting location (so don't accidentally make two walls in the same 
        //place), then builds a wall in each location for the number of spaces given, either moving RIGHT if
        // Horizontal ("Horz"), or DOWN if vertical ("vert"), and adds each wall piece to the World Objects
        //list
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
            else if (dir == "DiagDown")
            {
                for (int i = 0; i < numSpaces + 1; i++)
                {
                    Wall wally = new Wall() { Spot = new Location() { Row = startRow + i, Column = startCol + i } };
                    GameController.Instance.Level.WorldObj.Add(wally);

                }
            }
            else if (dir == "DiagUp")
            {
                for (int i = numSpaces + 1; i > 0; i--)
                {
                    Wall wally = new Wall() { Spot = new Location() { Row = startRow - i, Column = startCol + i } };
                    GameController.Instance.Level.WorldObj.Add(wally);

                }
            }
        }

        //surrounds the sides of the map
        public static void BuildEdges()
        {
            WallBuilder(0, 0, 30, "Horz");
            WallBuilder(1, 0, 22, "Vert");
            WallBuilder(23, 1, 30, "Horz");
            WallBuilder(0, 31, 22, "Vert");

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


        public static void LevelOne()
        {
            BuildEdges();

            //Edges of smaller map

            WallBuilder(15, 1, 20, "Horz");
            WallBuilder(1, 22, 13, "Vert");

            //Swirl in top left
            WallBuilder(4, 4, 2, "Horz");
            WallBuilder(5, 4, 1, "Vert");
            WallBuilder(6, 5, 3, "Horz");
            WallBuilder(2, 8, 3, "Vert");
            WallBuilder(2, 2, 5, "Horz");
            WallBuilder(3, 2, 5, "Vert");
            WallBuilder(8, 3, 7, "Horz");
            WallBuilder(1, 10, 7, "Vert");

            //Right Side

            WallBuilder(2, 12, 8, "Horz");
            WallBuilder(3, 12, 10, "Vert");
            WallBuilder(11, 14, 2, "Vert");
            WallBuilder(13, 15, 5, "Horz");
            WallBuilder(4, 20, 8, "Vert");
            WallBuilder(4, 14, 5, "Horz");
            WallBuilder(5, 14, 4, "Vert");
            WallBuilder(9, 15, 1, "Horz");
            WallBuilder(10, 16, 1, "Vert");
            WallBuilder(11, 17, 1, "Horz");
            WallBuilder(6, 18, 4, "Vert");
            WallBuilder(6, 16, 2, "Horz");
            WallBuilder(7, 16, 0, "Vert");

            //Bottom Left
            WallBuilder(12, 10, 2, "Vert");
            WallBuilder(11, 8, 2, "Vert");
            WallBuilder(10, 2, 4, "Vert");
            WallBuilder(10, 3, 8, "Horz");
            WallBuilder(12, 6, 2, "Vert");
            WallBuilder(12, 4, 1, "Horz");
            WallBuilder(13, 4, 0, "Vert");
        }

        //Makes one version of the quadrant for level two.

        //Takes an integer to tell which number quadrant is being built, then builds it and adds
        //All walls to the WorldObjects list
        public static void LevelTwo(int quadrant)
        {

            BuildEdges();

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

            WallBuilder(3 + addDown, 0 + addRight, 7, "Vert");
            WallBuilder(7 + addDown, 1 + addRight, 3, "Vert");
            WallBuilder(4 + addDown, 2 + addRight, 1, "Vert");
            WallBuilder(7 + addDown, 3 + addRight, 3, "Vert");
            WallBuilder(7 + addDown, 3 + addRight, 3, "Vert");
            WallBuilder(5 + addDown, 5 + addRight, 4, "Vert");
            WallBuilder(8 + addDown, 6 + addRight, 1, "Vert");
            WallBuilder(2 + addDown, 7 + addRight, 1, "Vert");
            WallBuilder(7 + addDown, 7 + addRight, 1, "Vert");
            WallBuilder(7 + addDown, 8 + addRight, 3, "Vert");
            WallBuilder(1 + addDown, 9 + addRight, 2, "Vert");
            WallBuilder(4 + addDown, 13 + addRight, 1, "Vert");
            WallBuilder(3 + addDown, 15 + addRight, 7, "Vert");
            WallBuilder(1 + addDown, 3 + addRight, 4, "Vert");

            //Horizontals of top left quadrant

            WallBuilder(0 + addDown, 0 + addRight, 13, "Horz");
            WallBuilder(1 + addDown, 5 + addRight, 2, "Horz");
            WallBuilder(2 + addDown, 0 + addRight, 1, "Horz");
            WallBuilder(2 + addDown, 11 + addRight, 4, "Horz");
            WallBuilder(3 + addDown, 4 + addRight, 1, "Horz");
            WallBuilder(4 + addDown, 9 + addRight, 3, "Horz");
            WallBuilder(5 + addDown, 6 + addRight, 1, "Horz");
            WallBuilder(6 + addDown, 9 + addRight, 1, "Horz");
            WallBuilder(7 + addDown, 9 + addRight, 1, "Horz");
            WallBuilder(7 + addDown, 12 + addRight, 2, "Horz");
            WallBuilder(8 + addDown, 12 + addRight, 2, "Horz");
            WallBuilder(9 + addDown, 10 + addRight, 4, "Horz");
            WallBuilder(11 + addDown, 3 + addRight, 8, "Horz");
            WallBuilder(0 + addDown, 0 + addRight, 1, "Horz");
            WallBuilder(10 + addDown, 13 + addRight, 1, "Horz");
        }


        //Builds walls for all of level 3, part 1
        public static void LevelThreePtOne()
        {
            WallBuilder(4, 1, 8, "Vert");
            WallBuilder(12, 2, 0, "Vert");
            WallBuilder(3, 1, 22, "Horz");
            WallBuilder(2, 6, 2, "Horz");
            WallBuilder(1, 12, 2, "Horz");
            WallBuilder(2, 18, 1, "Horz");
            WallBuilder(3, 25, 5, "Horz");
            WallBuilder(6, 3, 10, "Horz");
            WallBuilder(7, 3, 2, "Horz");
            WallBuilder(8, 3, 2, "Horz");
            WallBuilder(5, 14, 3, "Vert");
            WallBuilder(8, 7, 6, "Vert");
            WallBuilder(8, 11, 1, "Vert");
            WallBuilder(9, 9, 1, "Vert");
            WallBuilder(9, 11, 2, "Vert");
            WallBuilder(12, 1, 11, "Horz");
            WallBuilder(13, 3, 1, "Vert");
            WallBuilder(16, 1, 3, "Horz");
            WallBuilder(16, 1, 3, "Horz");
            WallBuilder(13, 9, 4, "Vert");
            WallBuilder(8, 15, 1, "Horz");
            WallBuilder(9, 15, 6, "Vert");
            WallBuilder(15, 14, 2, "Vert");
            WallBuilder(15, 16, 7, "Horz");
            WallBuilder(19, 2, 2, "Vert");

            //bottom section
            WallBuilder(19, 4, 25, "Horz");
            WallBuilder(20, 4, 21, "Horz");
            WallBuilder(21, 3, 21, "Horz");
            WallBuilder(17, 7, 1, "Vert");

            WallBuilder(13, 18, 1, "Vert");
            WallBuilder(4, 18, 7, "Vert");
            WallBuilder(10, 19, 1, "Horz");
            WallBuilder(11, 20, 1, "Vert");
            WallBuilder(18, 27, 1, "Vert");

            WallBuilder(7, 20, 10, "Horz");
            WallBuilder(5, 25, 13, "Vert");

            WallBuilder(8, 22, 6, "Vert");
            WallBuilder(10, 23, 0, "Vert");

            WallBuilder(12, 24, 1, "Vert");
            WallBuilder(10, 26, 4, "Horz");
            WallBuilder(11, 27, 3, "Horz");
            WallBuilder(12, 27, 3, "Vert");
        }


        //Builds walls for all of Level 3, part Two
        public static void LevelThreePtTwo()
        {

            BuildEdges();

            WallBuilder(1, 2, 5, "Vert");
            WallBuilder(8, 1, 3, "Horz");
            WallBuilder(15, 1, 7, "Horz");
            WallBuilder(16, 1, 7, "Horz");
            WallBuilder(16, 1, 7, "Horz");
            WallBuilder(10, 2, 2, "Horz");
            WallBuilder(12, 2, 3, "Horz");
            WallBuilder(13, 2, 3, "Horz");
            WallBuilder(2, 4, 4, "Vert");
            WallBuilder(2, 5, 4, "Vert");
            WallBuilder(8, 6, 5, "Vert");
            WallBuilder(3, 7, 5, "Vert");
            WallBuilder(1, 8, 2, "Vert");
            WallBuilder(1, 9, 2, "Vert");
            WallBuilder(2, 10, 1, "Horz");
            WallBuilder(2, 12, 5, "Vert");

            WallBuilder(6, 11, 1, "Vert");
            WallBuilder(6, 10, 1, "Vert");
            WallBuilder(5, 9, 8, "Vert");
            WallBuilder(10, 8, 3, "Vert");

            WallBuilder(18, 2, 4, "Vert");
            WallBuilder(17, 4, 4, "Vert");
            WallBuilder(18, 6, 4, "Vert");
            WallBuilder(18, 7, 1, "Horz");
            WallBuilder(20, 8, 3, "Horz");
            WallBuilder(13, 10, 5, "Vert");
            WallBuilder(16, 11, 1, "Vert");
            WallBuilder(18, 12, 2, "Vert");
            WallBuilder(18, 13, 1, "Horz");
            WallBuilder(16, 12, 2, "Horz");
            WallBuilder(17, 4, 4, "Vert");
            WallBuilder(15, 15, 3, "Vert");
            WallBuilder(11, 12, 3, "Vert");
            WallBuilder(14, 13, 0, "Vert");
            WallBuilder(4, 14, 9, "Vert");
            WallBuilder(1, 14, 1, "Vert");
            WallBuilder(1, 15, 1, "Vert");
            WallBuilder(1, 16, 5, "Vert");
            WallBuilder(8, 16, 3, "Vert");
            WallBuilder(11, 15, 0, "Vert");
            WallBuilder(1, 19, 10, "Vert");
            WallBuilder(11, 15, 0, "Vert");
            WallBuilder(13, 15, 3, "Horz");
            WallBuilder(13, 19, 9, "Vert");
            WallBuilder(15, 17, 1, "Horz");
            WallBuilder(17, 17, 1, "Horz");
            WallBuilder(19, 17, 1, "Horz");
            WallBuilder(20, 14, 2, "Vert");
            WallBuilder(21, 16, 1, "Vert");
            WallBuilder(21, 18, 0, "Horz");
        }

    }

}
