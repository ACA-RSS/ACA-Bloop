//everything that shows up on the map. Contains an image and a location
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


        //converts the object's key stats into a strin
        public abstract string Serialize();

        //converts a string containing a world object's stats into a instance of the object
        public abstract WorldObject Deserialize(string s);

    }

    
}
