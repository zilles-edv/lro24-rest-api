namespace LRO24.REST.Contract {
    public enum TourStatus {
        Deaktiviert = 0,
        Initial = 10,
        ZurueckAnDisposition = 15,
        Freigegeben = 35,
        InBearbeitung = 50,
        Unterbrochen = 70,
        LadeplanGedruckt = 75,
        Abgeschlossen = 80,
        Quickcheck = 98,
        Dummy = 99
    }
}
