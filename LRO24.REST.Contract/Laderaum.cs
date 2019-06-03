using System.Collections.Generic;

namespace LRO24.REST.Contract
{
    public class Laderaum
    {
        public int nummer { get; set; }

        public string typ { get; set; }

        public string kennzeichen { get; set; }

        public string freitext { get; set; }

        public int? reservierteLadeflaecheVorne { get; set; }

        public int? reservierteLadeflaecheVorneGewicht { get; set; }

        public int? reservierteLadeflaecheHinten { get; set; }

        public int? reservierteLadeflaecheHintenGewicht { get; set; }

        public int? innenlaenge { get; set; }

        public int? innenbreite { get; set; }

        public int? innenhoehe { get; set; }

        public int? anzahlDielen { get; set; }

        public int? anzahlTrennwaende { get; set; }

        public int? anzahlSpanngurte { get; set; }

        public List<Sicherungstexteintrag> sicherungstexte { get; set; } = new List<Sicherungstexteintrag>();
    }
}