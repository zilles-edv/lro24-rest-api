using System;

namespace LRO24.REST.Contract {
    public class Packstueck {
        public string schluessel { get; set; }
        public string nummer { get; set; }
        public string typ { get; set; }
        public string auftragsnummer { get; set; }
        public string ladestelle { get; set; }
        public string inhalt { get; set; }
        public int laenge { get; set; }
        public int breite { get; set; }
        public int hoehe { get; set; }
        public int brutto { get; set; }
        public int? netto { get; set; }
        public int? tara { get; set; }
        public int? stopNr { get; set; }
        public string lieferung { get; set; }
        public string materialbezeichnung { get; set; }
        public string materialnummer { get; set; }
        public bool? zwingendUnten { get; set; }
        public bool? nichtStapelbar { get; set; }
        public bool? nichtBelastbar { get; set; }
        public int? anzahlStapelbar { get; set; }
        public bool? stirnwand { get; set; }
        public string versandstelle { get; set; }
        public string routeText { get; set; }
        public bool? umschlagpunkt { get; set; }
        public string externeVersandtexte { get; set; }
    }
}