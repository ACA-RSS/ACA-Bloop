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
            else if (dir == "DiagDown")
            {
                for(int i = 0; i < numSpaces + 1; i++)
                {
                    Wall wally = new Wall() { Spot = new Location() { Row = startRow + i, Column = startCol + i } };
                    GameController.Instance.Level.WorldObj.Add(wally);

                }
            }
            else if (dir == "DiagUp")
            {
                for (int i = numSpaces + 1 ; i > 0 ; i--)
                {
                    Wall wally = new Wall() { Spot = new Location() { Row = startRow - i, Column = startCol + i } };
                    GameController.Instance.Level.WorldObj.Add(wally);

                }
            }
        }

        public static void BuildEdges()
        {
            Wall.WallBuilder(0, 0, 30, "Horz");
            Wall.WallBuilder(1, 0, 22, "Vert");
            Wall.WallBuilder(23, 1, 30, "Horz");
            Wall.WallBuilder(0, 31, 22, "Vert");
            
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
        public static void LevelThreePtOne()
        {
            //Edges of the map
            //entire top edge
            Wall.WallBuilder(0, 0, 31, "Horz");
            //rest of left side
            Wall.WallBuilder(1, 0, 22, "Vert");
            //entire bottom edge
            Wall.WallBuilder(23, 1, 29, "Horz");
            //rest of right side
            Wall.WallBuilder(1, 31, 22, "Vert");
            //Top walls
            Wall.WallBuilder(1, 6, 2, "Vert");
            Wall.WallBuilder(4, 7, 5, "DiagDown");
            Wall.WallBuilder(9, 13, 1, "Horz");
            Wall.WallBuilder(9, 16, 2, "Horz");
            Wall.WallBuilder(9, 18, 5, "DiagUp");
            Wall.WallBuilder(1, 24, 2, "Vert");
            //Bottom walls
            Wall.WallBuilder(20, 6, 2, "Vert");
            Wall.WallBuilder(20, 6, 5, "DiagUp");
            Wall.WallBuilder(14, 13, 1, "Horz");
            Wall.WallBuilder(14, 16, 1, "Horz");
            Wall.WallBuilder(14, 18, 5, "DiagDown");
            Wall.WallBuilder(20, 24, 2, "Vert");
            //Right Side walls
            Wall.WallBuilder(9, 27, 5, "Vert");
            Wall.WallBuilder(14, 28, 2, "Horz");
            Wall.WallBuilder(9, 29, 3, "Vert");
            Wall.WallBuilder(9, 30, 0, "Horz");


        }

        public static void LevelThreePtTwo()
        {
            Wall.WallBuilder(4, 1, 8, "Vert");
            Wall.WallBuilder(12, 2, 1, "Vert");
            Wall.WallBuilder(3, 1, 23, "Horz");
            Wall.WallBuilder(2, 6, 3, "Horz");
            Wall.WallBuilder(1, 12, 3, "Horz");
            Wall.WallBuilder(2, 18, 2, "Horz");
            Wall.WallBuilder(3, 25, 6, "Horz");
        }
    }

}
