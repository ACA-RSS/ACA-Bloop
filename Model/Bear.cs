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
            HitPoints = 25;
            AttackSpeed = 2;
            Damage = 15;
            Dead = false;
            Speed = 0;
            Image = "Images/bigber.gif";
            AttackTime = 0;
        }


        public override Location Move()
        {
            return Spot;
        }

        public override WorldObject Load(string statsStr)
        {
            Bear b = new Bear();
            string[] stats = statsStr.Split(',');
            b.HitPoints = Convert.ToInt32(stats[0]);
            b.Dead = Convert.ToBoolean(stats[0]);
            return b;
            //Spot = however we want to save spot
        }

        public override string Save()
        {
            return string.Format("Bear,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
