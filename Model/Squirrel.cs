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

            HitPoints = 5;
            AttackSpeed = 0.5;
            Speed = 5;
            Damage = 5;
            Dead = false;
            AttackTime = 0;
            Type = "Hittable";
        }

        public override Location Move()
        {
            Location potentialSpot = new Location { Row = Spot.Row, Column = Spot.Column };

            if (GameController.Instance.Player.Spot.Column > Spot.Column)
            {
                potentialSpot = new Location { Row = Spot.Row, Column = Spot.Column + Speed };
            }

            else
            {
                potentialSpot = new Location { Row = Spot.Row, Column = Spot.Column - Speed };
            }

            if (GameController.Instance.Player.Spot.Row > Spot.Row)
            {
                potentialSpot = new Location { Row = Spot.Row + Speed, Column = Spot.Column };
            }

            else
            {
                potentialSpot = new Location { Row = Spot.Row - Speed, Column = Spot.Column };
            }

            if (GameController.Instance.Level.Squares[potentialSpot.Row, potentialSpot.Column] == null)
            {
                Spot = potentialSpot;
            }

            return Spot;

        }

        public override WorldObject Deserialize(string statsStr)
        {
            Squirrel s = new Squirrel();
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[1]);
            Dead = Convert.ToBoolean(stats[2]);
            return s;
            //Spot = however we want to save spot
        }

        public override string Serialize()
        {
            return string.Format("Squirrel,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
