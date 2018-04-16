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
            AttackSpeed = 80 * GameController.Instance.Difficulty * 0.5;
            Speed = 30;
            Damage = 3 * GameController.Instance.Difficulty;
            Dead = false;
            MoveTime = 0;
            Image = "/Wolf.gif";
            AttackTime = 0;
            EyeContact = false;
            Type = "Hittable";
            PointValue = 15;
            Sound = Properties.Resources.WolfSound;
        }
        public override WorldObject Deserialize(string statsStr)
        {
            Wolf w = new Wolf();
            string[] stats = statsStr.Split(',');
            w.HitPoints = Convert.ToInt32(stats[1]);
            w.Dead = Convert.ToBoolean(stats[2]);
            w.EyeContact = Convert.ToBoolean(stats[3]);
            w.Spot = new Location(string.Format("{0},{1}", stats[4], stats[5]));
            return w;

        }

        public override string Serialize()
        {
            return string.Format("Wolf,{0},{1},{2},{3}", HitPoints, Dead, EyeContact, Spot);
        }

        //Tracking ability that begins as soon as eye contact is
        // made (See Move()). If the player's column is greater than the wolfs, it moves up
        //a column based on its speed, otherwise it moves down. 
        //Same logic for the row. So it starts with a new location, checks if that location is occupied by
        //Anything else, and then moves there.
        public Location Track()
        {
            
            int potentialCol;
            int potentialRow;
            if (EyeContact)
            {

                if (GameController.Instance.Player.Spot.Column > Spot.Column)
                {
                    potentialCol = Spot.Column + 1;
                    Image = "/Wolf.gif";
                }

                else if (GameController.Instance.Player.Spot.Column < Spot.Column)
                {
                    potentialCol = Spot.Column - 1;
                    Image = "/Wolf-Left.gif";
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
                if (GameController.Instance.Level.Squares[potentialSpot.Row, potentialSpot.Column] == null)
                {
                    Spot = potentialSpot;
                }
            }

            return Spot;
        }

        //Checks if eye contact has been made by determining if the player is on the same row as the wolf,
        //Then checks every spot along the row between the them to see if any location has a wall
        //If there is no wall and they're on the same row, it sets Eye Contact to true.
        //If eye contact is true, the wolf tracks (See Track())
        public override Location Move()
        {

            if (!EyeContact)
            {
                if (Spot.Row == GameController.Instance.Player.Spot.Row)
                {
                    bool isWall = false;
                    if (Spot.Column < GameController.Instance.Player.Spot.Column)
                    {
                        for (int i = Spot.Column; i < GameController.Instance.Player.Spot.Column; i++)
                        {
                            if (GameController.Instance.Level.Squares[Spot.Row, i] != null && GameController.Instance.Level.Squares[Spot.Row, i].Type == "Wall")
                            {
                                isWall = true;
                            }
                        }

                        if (!isWall)
                        {
                            EyeContact = true;
                        }
                    }
                    else
                    {
                        for (int i = GameController.Instance.Player.Spot.Column; i < Spot.Column; i++)
                        {
                            if (GameController.Instance.Level.Squares[Spot.Row, i] != null && GameController.Instance.Level.Squares[Spot.Row, i].Type == "Wall")
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
            }
            else
            {
                Track();
            }
            return Spot;


        }

    }
}

