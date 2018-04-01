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

        public Stick(string statsStr)
        {
            string[] stats = statsStr.Split(',');
            Damage = Convert.ToInt32(stats[1]);
           // Spot.Row = stats[1];
           // Spot.Column = stats[2];
            
        }

        public override string ToString()
        {
            return string.Format("Stick,{0},{1}", Damage, Spot);
        }
    }
}
