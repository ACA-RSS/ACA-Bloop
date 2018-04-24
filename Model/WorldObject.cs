using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public abstract class WorldObject: ISerializable
    {
        public string Image {get; set;}
        public Location Spot {get; set;}

        public string Type { get; set; }

        public abstract string Serialize();

        public abstract WorldObject Deserialize(string s);

    }

    
}
