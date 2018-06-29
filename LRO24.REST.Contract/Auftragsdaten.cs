using System;

namespace LRO24.REST.Contract {
    public class Auftragsdaten {
        public string auftragsnummer { get; set; }
        public string kunde { get; set; }
        public string kundennummer { get; set; }
        public string lieferadresse { get; set; }
        public string text { get; set; }
    }
}