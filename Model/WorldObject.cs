//Contains all code defining abstract WorldObject

//Base class for all entities on the map. Contains an image and a location
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public abstract class WorldObject: ISerializable
    {
        //The string to be used to create the image that is displayed for the object
        public string Image {get; set;}

        //Member of the Location struct; defines where in the grid the object is
        public Location Spot {get; set;}

        //String used to identify which derived class the object belongs to
        public string Type { get; set; }


        //converts the object's key stats into a strin
        public abstract string Serialize();

        //converts a string containing a world object's stats into a instance of the object
        public abstract WorldObject Deserialize(string s);

    }

    
}
