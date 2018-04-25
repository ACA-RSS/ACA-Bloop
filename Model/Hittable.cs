//abstract class of hittable things that eventually need to be removed from the board
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public abstract class Hittable : WorldObject
    {
        //the animals dead or alive status
        public bool Dead { get; set; }
        //how many hitpoints (health) an object has
        public int HitPoints { get; set; }
        //takes damage from attacks and updates `dead` and `hitpoints`
        public abstract void TakeDamage(int damage);
    }
}
