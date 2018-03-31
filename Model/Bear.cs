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
        }

        public override int Attack()
        {

            throw new NotImplementedException();

        }

        public override Location Move()
        {
            return Spot;
        }

    }
}
