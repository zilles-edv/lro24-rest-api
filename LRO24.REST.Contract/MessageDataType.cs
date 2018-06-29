using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRO24.REST.Contract {
    public enum MessageDataType {
        Unknown = 0,
        Json = 1,
        Base64ByteArray = 2,
        Text = 3
    }
}
