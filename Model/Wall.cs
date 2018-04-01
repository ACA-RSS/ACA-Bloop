using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wall : Terrain
    {
        public Wall(string statsStr)
        {
            string[] stats = statsStr.Split(',');
            //Spot = however we want to save spot
        }

        public override string ToString()
        {
            return string.Format("Wall,{0}", Spot);
        }
    }
    
}
