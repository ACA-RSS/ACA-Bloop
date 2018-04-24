using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Stump : Hittable
    {
        public WorldObject Object {get; set;}

        public Stump(WorldObject obj, int hp){
            Object = obj;
            HitPoints = hp;
            Type = "Hittable";
            Image = "/stump.png";
            Dead = false;
        }
        public Stump()
        {
            Object = new Stick(1000000000);
            HitPoints = 10;
            Type = "Hittable";
            Dead = false;
            Image = "/stump.png";
        }

        public Stump(int hp)
        {
            //if by some odd chance we make a stump and forget to edit the stick it drops,
            //the user gets a super stick
            Object = new Stick(1000000000);
            HitPoints = hp;
            Type = "Hittable";
            Dead = false;
            Image = "/stump.png";
        }

        //Removes the player's Damage from the hit points. If hit points are at or below 0, it releases it's object
        // And a squirrel in every direction
        public override void TakeDamage(int damage)
        {
            HitPoints -= damage;

            if (HitPoints <= 0)
            {
                Dead = true;
                ReleaseTheSquirrels();
                GameController.Instance.Level.WorldObj.Remove(this);
                Object.Spot = new Location { Row = Spot.Row, Column = Spot.Column };
                GameController.Instance.Level.WorldObj.Add(Object);
            }
        }

        //Makes 4 new squirrels and places them around the stump
        public void ReleaseTheSquirrels()
        {
            Squirrel s = new Squirrel();
            Squirrel q = new Squirrel();
            Squirrel u = new Squirrel();
            Squirrel i = new Squirrel();

            s.Spot = new Location { Row = Spot.Row + 1, Column = Spot.Column };
            q.Spot = new Location { Row = Spot.Row - 1, Column = Spot.Column };
            u.Spot = new Location { Row = Spot.Row, Column = Spot.Column + 1 };
            i.Spot = new Location { Row = Spot.Row, Column = Spot.Column - 1 };

            GameController.Instance.Level.WorldObj.Add(s);
            GameController.Instance.Level.WorldObj.Add(q);
            GameController.Instance.Level.WorldObj.Add(u);
            GameController.Instance.Level.WorldObj.Add(i);
        }

        public override WorldObject Deserialize(string statsStr)
        {
            
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[2]);
            string type = stats[6];
            Stump s = new Stump(HitPoints);
            s.Image = stats[5];
            s.Spot = new Location(string.Format("{0},{1}", stats[3], stats[4]));
            s.Dead = Convert.ToBoolean(stats[1]);
            switch (type)
            {
                case "Bear":
                    {
                        Bear b = new Bear();
                        s.Object = b;
                        break;
                    }
                case "Star":
                    {
                        Star st = new Star();
                        s.Object = st;
                        break;
                    }
                case "Boost":
                    {
                        Boost bo = new Boost();
                        s.Object = bo;
                        break;
                    }
                case "Stick":
                    {
                        Stick danger = new Stick();
                        s.Object = danger;
                        break;
                    }
            }
            return s;
        }

        public override string Serialize()
        {
            //spot will convert itselft to s comma seperated string already
            return string.Format("Stump,{0},{1},{2},{3},{4}", Dead, HitPoints, Spot, Image, Object.Serialize());
        }
    }
}
