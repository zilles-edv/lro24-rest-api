using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRO24.REST.Contract {
    public enum MessageType {
        Unknown = 0,
        TourInBearbeitung = 1,
        LadeplanPdf = 2,
        TourAbgeschlossen = 3,
        TourZurueckAnDispo = 4,
        TourFreigegeben = 5,
    }
}
