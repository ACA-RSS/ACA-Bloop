//Squirrel: annoying little guys that come in packs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    class Squirrel : Animals
    {
        public Squirrel()
        {

            HitPoints = 5 * GameController.Instance.Difficulty;
            AttackSpeed = 50 * GameController.Instance.Difficulty * 0.5;
            Speed = 20;
            Damage = 1 * GameController.Instance.Difficulty;
            Dead = false;
            AttackTime = 0;
            MoveTime = 0;
            Type = "Hittable";
            Image = "/squirrel.gif";
            AttackImage = "/squirrel.gif";
            PointValue = 5;
           // Sound = Properties.Resources.SquirrelSound;
        }

        //Tracking ability that begins as soon as the squirrel is generated. If the player's column is
        //Greater than the squirrel's, it moves up a column based on its speed, otherwise it moves down. 
        //Same logic for the row. So it starts with a new location, checks if that location is occupied by
        //Anything else, and then moves there.
        public override Location Move()
        {
            int potentialCol;
            int potentialRow;
            if (GameController.Instance.Player.Spot.Column > Spot.Column)
            {
                potentialCol = Spot.Column + 1;
            }

            else if (GameController.Instance.Player.Spot.Column < Spot.Column)
            {
                potentialCol = Spot.Column - 1;
            }
            else
            {
                potentialCol = Spot.Column;
            }

            if (GameController.Instance.Player.Spot.Row > Spot.Row)
            {
                potentialRow = Spot.Row + 1;
            }

            else if (GameController.Instance.Player.Spot.Row < Spot.Row)
            {
                potentialRow = Spot.Row - 1;
            }

            else
            {
                potentialRow = Spot.Row;
            }

            Location potentialSpot = new Location { Row = potentialRow, Column = potentialCol };
                Spot = potentialSpot;
            return Spot;
        }

        public override WorldObject Deserialize(string statsStr)
        {
            Squirrel s = new Squirrel();
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[1]);
            Dead = Convert.ToBoolean(stats[2]);
            s.Spot = new Location(string.Format("{0},{1}", stats[3], stats[4]));
            return s;
        }

        public override string Serialize()
        {
            return string.Format("Squirrel,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
