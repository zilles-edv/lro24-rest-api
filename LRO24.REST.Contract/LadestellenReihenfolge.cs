using System;

namespace LRO24.REST.Contract
{
    [Serializable]
    public class LadestellenReihenfolge
    {
        public int laderaumNummer { get; set; }

        public string ladestelle { get; set; }

        public string maeg { get; set; }

        public string ladestellenreihenfolge { get; set; }
    }
}