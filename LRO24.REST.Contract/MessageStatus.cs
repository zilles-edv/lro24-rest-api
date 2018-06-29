using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRO24.REST.Contract {
    public enum MessageStatus {
        Initial = 0,
        InVerarbeitung = 1,
        Verarbeitet = 2,
        Fehlerhaft = 3,
        Ignoriert = 4
    }
}
