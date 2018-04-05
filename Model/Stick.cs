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

        public override WorldObject Deserialize(string statsStr)
        {

            //string[] stats = statsStr.Split(',');
            //Stick s = new Stick();
            //Damage = Convert.ToInt32(stats[1]);
            // Spot.Row = stats[1];
            // Spot.Column = stats[2];
            Bear x = new Bear();
            return x;

        }

        public override string Serialize()
        {
            return string.Format("Stick,{0},{1}", Damage, Spot);
        }
    }
}
