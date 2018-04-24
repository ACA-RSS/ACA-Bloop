using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Character : Animate
    {
        public Stick Stick;

        public Location StartSpot;


        public Character()
        {
            HitPoints = 100;
            Stick = new Stick(5);
            Damage = Stick.Damage;
            Dead = false;
            Spot = new Location { Row = 12, Column = 0 };
            StartSpot = new Location { Row = 12, Column = 0 };
            //Image = "/Sue.gif";
            Type = "Character";
            DirFacing = Direction.Up;

        }

        public Character(string img)
        {
            HitPoints = 100;
            Stick = new Stick(5);
            Damage = Stick.Damage;
            Dead = false;
            Spot = new Location { Row = 12, Column = 0 };
            StartSpot = new Location { Row = 12, Column = 0 };
            Image = img;
            Type = "Character";
            DirFacing = Direction.Up;
        }
        //Removes the character's damage from the animal's hitpoints
        public void doDamage(Hittable toAttack)
        {
            if (toAttack != null && !toAttack.Dead)
                toAttack.TakeDamage(Damage);
        }

        public void AttackImage()
        {
            if (GameController.Instance.GenderImg == "/Scotty.gif")
            {
                if (DirFacing == Direction.Right)
                {
                    Image = "/Scotty-Attack.png";
                }
                else
                {
                    Image = "/Scotty-Left-Attack.png";
                }
            }
            else
            {
                if (DirFacing == Direction.Right)
                {
                    Image = "/Sue-Attack.png";
                }
                else
                {
                    Image = "/Sue-Left-Attack.png";
                }
            }
        }

        //Checks the direction the character is facing, then sees if there's an animal or stum (The hittable
        // sbstract class) one space in that direction. If so, it does damage to that object(See doDamage())
        public override int Attack()
        {
            int down = 0;
            int right = 0;
            

            GameController.Instance.CurrentSound = Properties.Resources.punch;
            switch (DirFacing)
            {
                case Direction.Up:
                    down = -1;
                    break;

                case Direction.Down:
                    down = 1;
                    break;

                case Direction.Left:
                    right = -1;
                    break;

                case Direction.Right:
                    right = 1;
                    break;
            }
            if (GameController.Instance.Level.Squares[Spot.Row + down, Spot.Column + right] != null && GameController.Instance.Level.Squares[Spot.Row + down, Spot.Column + right].Type == "Hittable")
            {
                doDamage(GameController.Instance.Level.Squares[Spot.Row + down, Spot.Column + right] as Hittable);
            }
            return Damage;

        }

        //Recieves a direction based on which keyboard button was pressed, then checks if
        //Moving in that direction will either take the player off the map or if something is already there
        //If both of these are false, it updates the player's location to the spot.
        public Location PlayerMove(string Dir)
        {
            Location oldPos;
            if (Dir == "Up")
            {
                DirFacing = Direction.Up;
                if (Spot.Row - 1 >= 0 && GameController.Instance.Level.Squares[Spot.Row - 1, Spot.Column] == null)
                {
                    oldPos = Spot;
                    Spot = new Location { Row = Spot.Row - 1, Column = Spot.Column };
                    GameController.Instance.Level.Squares[oldPos.Row, oldPos.Column] = null;
                }
            }
            else if (Dir == "Down")
            {
                DirFacing = Direction.Down;
                if (Spot.Row + 1 <= GameController.Instance.Level.Height - 1 && GameController.Instance.Level.Squares[Spot.Row + 1, Spot.Column] == null)
                {
                    oldPos = Spot;
                    Spot = new Location { Row = Spot.Row + 1, Column = Spot.Column };
                    GameController.Instance.Level.Squares[oldPos.Row, oldPos.Column] = null;
                }
            }
            else if (Dir == "Left")
            {
                DirFacing = Direction.Left;

                if (GameController.Instance.GenderImg == "/Scotty.gif")
                {
                    Image = "/Scot-Left.gif";
                }
                else
                {
                    Image = "/Sue-Left.gif";
                }

                if (Spot.Column - 1 >= 0 && GameController.Instance.Level.Squares[Spot.Row, Spot.Column - 1] == null)
                {
                    oldPos = Spot;
                    Spot = new Location { Row = Spot.Row, Column = Spot.Column - 1 };
                    GameController.Instance.Level.Squares[oldPos.Row, oldPos.Column] = null;
                }
            }
            else if (Dir == "Right")
            {

                Image = GameController.Instance.GenderImg;
                DirFacing = Direction.Right;
                {
                    if (Spot.Column + 1 <= GameController.Instance.Level.Width - 1 && GameController.Instance.Level.Squares[Spot.Row, Spot.Column + 1] == null)
                    {
                        oldPos = Spot;
                        Spot = new Location { Row = Spot.Row, Column = Spot.Column + 1 };
                        GameController.Instance.Level.Squares[oldPos.Row, oldPos.Column] = null;
                    }
                }
            }
            return Spot;
        }

        public override WorldObject Deserialize(string statsStr)
        {
            Character c = new Character();
            string[] stats = statsStr.Split(',');
            c.HitPoints = Convert.ToInt32(stats[1]);
            c.Dead = Convert.ToBoolean(stats[2]);
            c.Spot = new Location(string.Format("{0},{1}", stats[3], stats[4]));
            c.StartSpot = new Location(string.Format("{0},{1}", stats[5], stats[6]));
            return c;
        }

        public override void Die()
        {
            Dead = true;
            Image = "/Scotty-Dead.png";
        }

        public override string Serialize()
        {
            return string.Format("Character,{0},{1},{2},{3}", HitPoints, Dead, Spot, StartSpot);
        }
    }
}
