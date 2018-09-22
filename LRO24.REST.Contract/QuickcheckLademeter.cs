namespace LRO24.REST.Contract
{
    public class QuickcheckLademeter
    {
        public double lademeter { get; set; }
        public double gesamtlaenge { get; set; }
        public int anzahlNichtVerladenePackstuecke { get; set; }
        public double lademeterNichtInLaderaum { get; set; }
    }
}