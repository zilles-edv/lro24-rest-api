using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRO24.REST.Contract {
    public class LoginRequest {
        public string benutzername { get; set; }
        public string passwort { get; set; }
        public string mandantName { get; set; }
    }
}
