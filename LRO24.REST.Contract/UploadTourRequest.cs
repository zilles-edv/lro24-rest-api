namespace LRO24.REST.Contract
{
    public class UploadTourRequest
    {
        public Tour tour { get; set; }

        public bool? ladeplanVerwerfen { get; set; }
    }
}