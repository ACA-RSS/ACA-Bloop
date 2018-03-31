using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Stick : WorldObject
    {
        public int Damage { get; set; }

        public Stick(int hurt)
        {
            Damage = hurt;
        }
    }
}
