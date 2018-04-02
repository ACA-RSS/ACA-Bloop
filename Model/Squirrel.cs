using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    class Squirrel : Animals
    {
        public Squirrel()
        {

            HitPoints = 5;
            AttackSpeed = 0.5;
            Speed = 5;
            Damage = 5;
            Dead = false;
            AttackTime = 0;
        }

        public override Location Move()
        {

            throw new NotImplementedException();

        }

        public override WorldObject Load(string statsStr)
        {
            Squirrel s = new Squirrel();
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[1]);
            Dead = Convert.ToBoolean(stats[2]);
            return s;
            //Spot = however we want to save spot
        }

        public override string Save()
        {
            return string.Format("Squirrel,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
