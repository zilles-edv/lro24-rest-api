namespace LRO24.REST.Contract
{
    public class UploadAuftragRequest
    {
        public Auftrag auftrag { get; set; }

        public bool fehlendeArtikelAnlegen { get; set; }
    }
}