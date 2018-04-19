using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Stick : Hittable
    {
        public int Damage { get; set; }

        public Stick(int hurt)
        {
            Damage = hurt;
            Image = "/Stick.png";
            Type = "Hittable";
        }

        public Stick()
        {
            Damage = 1337;
            Type = "Hittable";
            Image = "/Stick.png";
        }

        public override void TakeDamage(int damage)
        {
            GameController.Instance.Player.Stick = this;
            GameController.Instance.Level.WorldObj.Remove(this);
        }

        public override WorldObject Deserialize(string statsStr)
        {

            string[] stats = statsStr.Split(',');
            Stick s = new Stick(Convert.ToInt32(stats[1]));
            s.Spot = new Location(string.Format("{0},{1}", stats[2], stats[3]));
            return s;

        }

        public override string Serialize()
        {
            return string.Format("Stick,{0},{1}", Damage, Spot);
        }
    }
}
