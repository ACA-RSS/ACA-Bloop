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

        public Character()
        {
            HitPoints = 100;
            Stick = new Stick(5);
            Damage = Stick.Damage;
            Dead = false;
            Spot = new Location { Row = 0, Column = 0 };
            Type = "Character";
        }

        public void doDamage(Hittable toAttack)
        {
            if (!toAttack.Dead)
                toAttack.TakeDamage(Damage);
        }

        public override int Attack()
        {
            switch (DirFacing)
            {
                case Direction.Up:
                    if (GameController.Instance.Level.Squares[Spot.Row + 1, Spot.Column].Type == "Hittable")
                    {
                        doDamage(GameController.Instance.Level.Squares[Spot.Row, Spot.Column + 1] as Hittable);
                    }
                    break;

                case Direction.Down:
                    if (GameController.Instance.Level.Squares[Spot.Row + 1, Spot.Column].Type == "Hittable")
                    {
                        doDamage(GameController.Instance.Level.Squares[Spot.Row, Spot.Column + 1] as Hittable);
                    }

                    break;

                case Direction.Left:
                    if (GameController.Instance.Level.Squares[Spot.Row + 1, Spot.Column].Type == "Hittable")
                    {
                        doDamage(GameController.Instance.Level.Squares[Spot.Row, Spot.Column + 1] as Hittable);
                    }
                    break;

                case Direction.Right:
                    if (GameController.Instance.Level.Squares[Spot.Row + 1, Spot.Column].Type == "Hittable")
                    {
                        doDamage(GameController.Instance.Level.Squares[Spot.Row, Spot.Column + 1] as Hittable);
                    }
                    break;

            }

            return Damage;
        }

        public Location PlayerMove(string Dir)
        {
            if (Dir == "Up")
            {
                DirFacing = Direction.Up;
                if (Spot.Row - 1 >= 0 && GameController.Instance.Level.Squares[Spot.Row - 1, Spot.Column] == null)
                {
                    Spot = new Location { Row = Spot.Row - 1, Column = Spot.Column };
                }
            }
            else if (Dir == "Down" && GameController.Instance.Level.Squares[Spot.Row + 1, Spot.Column] == null)
            {
                DirFacing = Direction.Down;
                if (Spot.Row + 1 <= GameController.Instance.Level.Height)
                {
                    Spot = new Location { Row = Spot.Row + 1, Column = Spot.Column };
                }
            }
            else if (Dir == "Left")
            {
                DirFacing = Direction.Left;
                if (Spot.Column - 1 >= 0 && GameController.Instance.Level.Squares[Spot.Row, Spot.Column - 1] == null)
                {
                    Spot = new Location { Row = Spot.Row, Column = Spot.Column - 1 };
                }
            }
            else if (Dir == "Right" && GameController.Instance.Level.Squares[Spot.Row, Spot.Column + 1] == null)
            {
                DirFacing = Direction.Right;
                if (Spot.Column + 1 <= GameController.Instance.Level.Width)
                {
                    Spot = new Location { Row = Spot.Row, Column = Spot.Column + 1 };
                }
            }

            return Spot;

        }

        public override WorldObject Deserialize(string statsStr)
        {
            Character c = new Character();
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[1]);
            Dead = Convert.ToBoolean(stats[2]);
            return c;
            //Spot = however we want to save spot
        }

        public override string Serialize()
        {
            return string.Format("Character,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
