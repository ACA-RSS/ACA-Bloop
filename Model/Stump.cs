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
            Dead = false;
        }

        public override void TakeDamage(int damage)
        {
            HitPoints -= damage;

            if (HitPoints <= 0)
            {
                Dead = true;
                ReleaseTheSquirrels();
            }
        }

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
            Bear s = new Bear();
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[1]);
            return s;
            //Spot = however we want to save spot
        }

        public override string Serialize()
        {
            return string.Format("Stump,{0},{1}", HitPoints, Spot);
        }
    }
}
