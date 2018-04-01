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

        public Bear(string statsStr)
        {
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[0]);
            Dead = Convert.ToBoolean(stats[0]);
            //Spot = however we want to save spot
        }

        public override string ToString()
        {
            return string.Format("Bear,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
