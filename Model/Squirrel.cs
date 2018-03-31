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

    }
}
