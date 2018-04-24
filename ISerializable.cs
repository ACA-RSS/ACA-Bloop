using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model

{
    interface ISerializable
    {
        string Serialize();

        WorldObject Deserialize(string s);
    }
}
