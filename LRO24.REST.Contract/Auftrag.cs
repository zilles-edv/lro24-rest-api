using System.Collections.Generic;

namespace LRO24.REST.Contract
{
    public class Auftrag
    {
        public string nummer { get; set; }

        public string auftragsnummer { get; set; }

        public string kundenname { get; set; }

        public string kundennummer { get; set; }

        public string adresse { get; set; }

        public string verladedatum { get; set; }

        public string text { get; set; }

        public int status { get; set; }

        public List<Auftragsposition> positionen { get; set; } = new List<Auftragsposition>();

        public List<Packstueck> packstuecke { get; set; } = new List<Packstueck>();
    }
}