using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wolf : Animals
    {
        public Wolf()
        {

            HitPoints = 20;
            AttackSpeed = 1;
            Speed = 5;
            Damage = 10;
            Dead = false;
            Image = "Images/wolf.gif";
        }

        public override int Attack()
        {

            throw new NotImplementedException();

        }

        public override Location Move()
        {

            throw new NotImplementedException();

        }

    }
}
