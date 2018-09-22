using System.Collections.Generic;

namespace LRO24.REST.Contract
{
    public class Tour
    {
        public string id { get; set; }

        public string creationDate { get; set; }

        public string modificationDate { get; set; }

        public int? nummer { get; set; }

        public string guid { get; set; }

        public string bezeichnung { get; set; }

        public string unternehmer { get; set; }

        public string kunde { get; set; }

        public string tourtext { get; set; }

        public string vorladung { get; set; }

        public string datum { get; set; }

        /// <summary>
        /// <see cref="TourStatus" />
        /// </summary>
        public int? status { get; set; }

        public string vorladekennzeichen { get; set; }

        public string laderaumInfo { get; set; }

        public string packstueckInfo { get; set; }

        public int anzahlStops { get; set; }

        public int anzahlLieferungen { get; set; }

        public int anzahlPackstuecke { get; set; }

        public string benutzer { get; set; }

        public List<Packstueck> packstuecke { get; set; } = new List<Packstueck>();

        public List<Laderaum> laderaeume { get; set; } = new List<Laderaum>();

        public List<Auftragsdaten> auftragsdaten { get; set; } = new List<Auftragsdaten>();

        public List<LadestellenReihenfolge> ladestellenreihenfolge { get; set; } = new List<LadestellenReihenfolge>();
    }
}