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
            Image = "/Wall.png";
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
                    Wall wally = new Wall() { Spot = new Location() { Row = startRow , Column = startCol + i} };

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
        

        
    }
    
}
