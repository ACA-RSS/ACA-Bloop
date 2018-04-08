using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{

    public class Bear : Animals
    {

        public Bear()
        {
            HitPoints = 25 * GameController.Instance.Difficulty;
            AttackSpeed = 2;
            Damage = 15 * GameController.Instance.Difficulty;
            Dead = false;
            Speed = 0;
            Image = "Images/bigber.gif";
            AttackTime = 0;
            Type = "Hittable";
        }


        public override Location Move()
        {
            return Spot;
        }

        public override WorldObject Deserialize(string statsStr)
        {
            Bear b = new Bear();
            string[] stats = statsStr.Split(',');
            b.HitPoints = Convert.ToInt32(stats[1]);
            b.Dead = Convert.ToBoolean(stats[2]);
            Location l = new Location(string.Format("{0},{1}", stats[3], stats[4]));
            b.Spot = l;
            return b;
           
        }

        public override string Serialize()
        {
            return string.Format("Bear,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
