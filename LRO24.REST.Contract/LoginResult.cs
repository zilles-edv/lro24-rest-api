using System.Collections.Generic;

namespace LRO24.REST.Contract {
    public class LoginResult {
        public string apiToken { get; set; }
        public List<Mandant> mandanten { get; set; }
    }
}