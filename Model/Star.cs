using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    class Star : Hittable
    {
        public Star()
        {
            HitPoints = 1;
            Dead = false;
            Image = "/ster.png";
            Type = "Hittable";
        }

        public override void TakeDamage(int damage)
        {
            Dead = true;
            GameController.Instance.Level.Stars += 1;
            GameController.Instance.Points += 100 * GameController.Instance.Difficulty;
            GameController.Instance.Level.WorldObj.Remove(this);
        }

        public override WorldObject Deserialize(string statsStr)
        {
            Star st = new Star();
            string[] stats = statsStr.Split(',');
            Location l = new Location(string.Format("{0},{1}", stats[1], stats[2]));
            st.Spot = l;
            return st;
        }

        public override string Serialize()
        {
            return string.Format("Star,{0}", Spot);
        }
    }
}
