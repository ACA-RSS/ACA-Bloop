using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wolf : Animals
    {
        public bool EyeContact { get; set; }

        public Wolf()
        {

            HitPoints = 20;
            AttackSpeed = 1;
            Speed = 5;
            Damage = 10;
            Dead = false;
            Image = "Images/wolf.gif";
            AttackTime = 0;
            EyeContact = false;
        }
        public override WorldObject Load(string statsStr)
        {
            Wolf w = new Wolf();
            string[] stats = statsStr.Split(',');
            w.HitPoints = Convert.ToInt32(stats[1]);
            w.Dead = Convert.ToBoolean(stats[2]);
            return w;
            //Spot = however we want to save spot
        }

        public override string Save()
        {
            return string.Format("Wolf,{0},{1},{2}", HitPoints, Dead, Spot);
        }
    }

    public override Location Move()
        {

            throw new NotImplementedException();
            
            // Rough draft of tracking characteristic of wolves
           /*
            if (EyeContact) {
                double dist = Math.Pow((Math.Pow((Spot.Row - wan.X), 2) + Math.Pow((Spot.Column - wan.Y), 2)), 0.5);
                if (wan.X > Spot.Row)
                {
                    Spot.Row += Speed;
                }
                else
                {
                    Spot.Row -= Speed;
                }
                if (wan.Y > Spot.Column)
                {
                    Spot.Column += Speed;
                }
                else
                {
                    Spot.Column -= Speed;
                }
            }
            else return Spot;*/

        }

    }
}
