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
        }

        public override int Attack()
        {

            throw new NotImplementedException();

        }

        public override Location Move()
        {

            throw new NotImplementedException();

        }

        public Character(string statsStr)
        {
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[1]);
            Dead = Convert.ToBoolean(stats[2]);
            //Spot = however we want to save spot
        }

        public override string ToString()
        {
            return string.Format("Character,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }
}
