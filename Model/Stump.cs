using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Stump : Terrain
    {
        public int HitPoints {get; set;}
        public WorldObject Object {get; set;}

        public Stump(WorldObject obj, int hp){
            Object = obj;
            HitPoints = hp;

        }
        public Stump(string statsStr)
        {
            string[] stats = statsStr.Split(',');
            HitPoints = Convert.ToInt32(stats[1]);
            
            //Spot = however we want to save spot
        }

        public override string ToString()
        {
            return string.Format("Stump,{0},{1}", HitPoints, Spot);
        }
    }
}
