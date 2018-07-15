using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRO24.REST.Contract {
    public class Message {
        public string id { get; set; }

        public string date { get; set; }

        /// <summary>
        /// Enum als 'int' implementiert um Parser-Fehler zu vermeiden bei neuen/inkompatiblen Werten 
        /// wenn die Schnittstelle Serverseitig erweitert wird
        /// <see cref="MessageStatus" />
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// Enum als 'int' implementiert um Parser-Fehler zu vermeiden bei neuen/inkompatiblen Werten 
        /// wenn die Schnittstelle Serverseitig erweitert wird
        /// <see cref="MessageType" />
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// Enthaltene Nutzdaten. Je nach Typ kann dieses Feld unterschiedliche Daten enthalten (json / base64)
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// Der Typ der enthaltenen Daten (data)
        /// <see cref="MessageDataType" />
        /// </summary>
        public int dataType { get; set; }

        /// <summary>
        /// Feld das vom Empfänger nach belieben gefüllt werden kann.
        /// Kann für Debugging-Zwecke verwendet werden.
        /// </summary>
        public string info { get; set; }

        /// <summary>
        /// Benutzername
        /// </summary>
        public string username { get; set; }

        public MessageMetadata metadata { get; set; }

        public Message() {
            metadata = new MessageMetadata();
        }
    }
}
