using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wolf : Animals
    {
        public bool EyeContact { get; set; }

        public Wolf()
        {

            HitPoints = 20 * GameController.Instance.Difficulty;
            AttackSpeed = 1;
            Speed = 5;
            Damage = 10 * GameController.Instance.Difficulty;
            Dead = false;
            Image = "Images/wolf.gif";
            AttackTime = 0;
            EyeContact = false;
            Type = "Hittable";
        }
        public override WorldObject Deserialize(string statsStr)
        {
            Wolf w = new Wolf();
            string[] stats = statsStr.Split(',');
            w.HitPoints = Convert.ToInt32(stats[1]);
            w.Dead = Convert.ToBoolean(stats[2]);
            return w;
            //Spot = however we want to save spot
        }

        public override string Serialize()
        {
            return string.Format("Wolf,{0},{1},{2}", HitPoints, Dead, Spot);
        }


        public Location Track()
        {
            Location potentialSpot = new Location { Row = Spot.Row, Column = Spot.Column };
            if (EyeContact)
            {

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
            }
            return Spot;

        }

        public override Location Move()
        {

            if (!EyeContact)
            {
                if (Spot.Row == GameController.Instance.Player.Spot.Row)
                {
                    bool isWall = false;
                    for (int i = Spot.Column; i < GameController.Instance.Player.Spot.Column; i++)
                    {
                        if (GameController.Instance.Level.Squares[Spot.Row, i].Type == "Wall")
                        {
                            isWall = true;
                        }
                    }

                    if (!isWall)
                    {
                        EyeContact = true;
                    }
                }
            }

            Track();
            

            return Spot;


        }

    }
}

