using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    class Star : Hittable
    {
        public Star()
        {
            HitPoints = 0;
            Dead = false;
            Image = "/Wolf.png";
        }

        public override void TakeDamage(int damage)
        {
            Dead = true;
            GameController.Instance.Level.Stars += 1;
            GameController.Instance.Points += 100 * GameController.Instance.Difficulty;
        }

        public override WorldObject Deserialize(string s)
        {
            throw new NotImplementedException();
        }

        public override string Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
