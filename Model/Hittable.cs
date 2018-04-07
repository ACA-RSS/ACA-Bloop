using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public abstract class Hittable : WorldObject
    {
        public bool Dead { get; set; }
        public int HitPoints { get; set; }

        public abstract void TakeDamage(int damage);
    }
}
