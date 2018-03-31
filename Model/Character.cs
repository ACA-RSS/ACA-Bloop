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

    }
}
