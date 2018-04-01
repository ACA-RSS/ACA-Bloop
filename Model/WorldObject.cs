using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public abstract class WorldObject
    {
        public string Image {get; set;}
        public Location Spot {get; set;}

        public abstract string Save();

        public abstract WorldObject Load(string s);

    }

    
}
