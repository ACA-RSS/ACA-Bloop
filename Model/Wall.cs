using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wall : Terrain
    {
        public override WorldObject Deserialize(string statsStr)
        {
            string[] stats = statsStr.Split(',');
            return new Wolf();
            //Spot = however we want to save spot
        }

        public override string Serialize()
        {
            return string.Format("Wall,{0}", Spot);
        }
        

        
    }
    
}
