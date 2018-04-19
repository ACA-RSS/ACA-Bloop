using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twisted_Treeline;

namespace Twisted_Treeline.Model
{
    class Boost : Hittable
    {
        public int Bonus { get; set; }
        public Boost()
        {
            HitPoints = 1;
            Dead = false;
            Image = "/boost.png";
            Type = "Hittable";
            //how many health points to add to player
            Bonus = 5;
        }

        public override void TakeDamage(int damage)
        {
            Dead = true;
            GameController.Instance.Player.HitPoints += 5;
            GameController.Instance.Level.WorldObj.Remove(this);
        }

        public override WorldObject Deserialize(string statsStr)
        {
            Boost bo = new Boost();
            string[] stats = statsStr.Split(',');
            Location l = new Location(string.Format("{0},{1}", stats[1], stats[2]));
            bo.Spot = l;
            return bo;
        }

        public override string Serialize()
        {
            return string.Format("Boost,{0}", Spot);
        }
    }
}

