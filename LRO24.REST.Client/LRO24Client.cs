using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using LRO24.REST.Client.Helper;
using LRO24.REST.Contract;
using Newtonsoft.Json;

namespace LRO24.REST.Client
{
    public class LRO24Client
    {
        public LRO24Client()
        { }

        public LRO24Client(string url, string authToken, string mandant)
        {
            this.URL = url;
            this.AuthToken = authToken;
            this.Mandant = mandant;
        }

        /// <summary>
        /// URL zum LRO (z.B. https://www.lro24.de (PROD) order https://beta.laderaumplaner.de (Beta))
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// X-Auth-Token (siehe Administration / API)
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// X-Mandant (siehe Administration / API)
        /// </summary>
        public string Mandant { get; set; }

        /// <summary>
        /// Lädt eine Liste mit Touren. Es werden nur "Header"-Daten ausgegeben.
        /// </summary>
        public GetTourenResult GetTouren(int start = 0, int limit = 100, int[] status = null, string orderBy = "Nummer", OrderDirection orderDirection = OrderDirection.Desc)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/tour"
                + "?start=" + start
                + "&limit=" + limit
                + "&status=" + (status != null ? string.Join(",", status.Select(p => p.ToString())) : "")
                + "&orderBy=" + orderBy
                + "&orderDirection=" + orderDirection.ToString("G").ToLower();

            return Get<GetTourenResult>(url);
        }

        /// <summary>
        /// Lädt eine einzelne Tour
        /// </summary>
        public Tour GetTour(string id)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/tour/" + id;

            return Get<Tour>(url);
        }

        /// <summary>
        /// Überträgt eine Tour an LRO24.
        /// </summary>
        public UploadTourResult UploadTour(UploadTourRequest uploadTourRequest)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/tour";

            return Post<UploadTourResult>(url, uploadTourRequest);
        }

        /// <summary>
        /// Führt einen Quickcheck für die Tour durch. Es werden die geschätzen Lademeter berechnet und eine URL 
        /// zur Anzeige der Vorschau zurückgegeben
        /// </summary>
        public QuickcheckTourResult QuickcheckTour(QuickcheckTourRequest quickcheckTourRequest)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/tour/quickcheck";

            return Post<QuickcheckTourResult>(url, quickcheckTourRequest);
        }

        /// <summary>
        /// Einen fertigen Plan dynamisch anzeigen, analog zu <see cref="QuickcheckTour"/>
        /// </summary>
        public ReadyviewTourResult ReadyViewTour(ReadyviewTourRequest request)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/tour/readyview";

            return Post<ReadyviewTourResult>(url, request);
        }

        /// <summary>
        /// Eine per <see cref="UploadTour"/> an LRO24 übertragene Tour zurückholen. Funktioniert nur, solange die Tour noch nicht
        /// in Bearbeitung ist.
        /// </summary>
        public ZurueckAnDispoResult ZurueckAnDispo(ZurueckAnDispoResult request)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/tour/zurueckandispo";

            return Post<ZurueckAnDispoResult>(url, request);
        }

        /// <summary>
        /// Lädt das PDF (gedruckter) Ladeplan für eine Tour
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] GetTourPdf(string id)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/tour/pdf/" + id;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("x-auth-token", AuthToken);
            request.Headers.Add("x-mandant", Mandant);

            return ReadByteArrayResponse(request);
        }

        /// <summary>
        /// Wartet bis die nächste Nachricht zum Abholen bereitsteht.
        /// Gibt die nächste Nachricht zurück, oder NULL falls innerhalb der angegebenen Zeitspanne (Standard: 15 Sekunden)
        /// keine Nachricht empfangen wurde
        /// </summary>
        public Message WaitForNextMessage(int maxSeconds = 15)
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/export/wait?time=" + maxSeconds;

            return Get<Message>(url);
        }

        /// <summary>
        /// Holt die nächste Nachricht vom Server. Gibt NULL zurück, falls keine Nachricht zum abholen vorhanden ist
        /// </summary>
        public Message GetNextMessage()
        {
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/export/next";

            return Get<Message>(url);
        }

        /// <summary>
        /// Bestätigt den Empfang der Nachricht
        /// </summary>
        public void CommitMessage(Message message, string info = "")
        {
            info = info ?? "";
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/export/commit/" + message.id;

            Post<Message>(url, new
            {
                info = info
            });
        }

        /// <summary>
        /// Markiert die Nachricht als "Fehlerhaft"
        /// </summary>
        public void FailMessage(Message message, string info = "")
        {
            info = info ?? "";
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/export/fail/" + message.id;

            Post<Message>(url, new
            {
                info = info
            });
        }

        /// <summary>
        /// Markiert die Nachricht als zu "Ignorieren"
        /// </summary>
        public void IgnoreMessage(Message message, string info = "")
        {
            info = info ?? "";
            string url = URL.NormalizeUrl() + "/server/api/REST/v1/export/ignore/" + message.id;

            Post<Message>(url, new
            {
                info = info
            });
        }

        private T Post<T>(string url, object param) where T : class
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("x-auth-token", AuthToken);
            request.Headers.Add("x-mandant", Mandant);

            string json = JsonConvert.SerializeObject(param);

            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            return ReadJsonResponse<T>(request);
        }

        private T Get<T>(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("x-auth-token", AuthToken);
            request.Headers.Add("x-mandant", Mandant);

            return ReadJsonResponse<T>(request);
        }

        private byte[] ReadByteArrayResponse(HttpWebRequest request)
        {
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.GetResponseStream().ToByteArray();
                }
            }
            catch (WebException ex)
            {
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8);
                string message = reader.ReadToEnd();

                throw new Exception(message);
            }
        }

        private T ReadJsonResponse<T>(HttpWebRequest request)
        {
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string jsonResult = reader.ReadToEnd();

                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }
            }
            catch (WebException ex)
            {
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8);
                string message = reader.ReadToEnd();

                throw new Exception(message);
            }
        }

        private static string EncodeUrlParam(string unicodeString)
        {
            if (unicodeString == null)
            {
                return "";
            }

            char[] allowedUrlParamChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-".ToCharArray();
            var encoding = Encoding.Default;
            byte[] bytes = encoding.GetBytes(unicodeString);

            var builder = new StringBuilder();

            foreach (byte b in bytes)
            {
                char c = (char)b;

                if (allowedUrlParamChars.Contains(c))
                {
                    builder.Append(c);
                }
                else
                {
                    builder.Append("%" + b.ToString("X2"));
                }
            }

            return builder.ToString();
        }
    }
}