namespace LRO24.REST.Contract
{
    public class ReadyviewTourResult : SaveResult
    {
        public string url { get; set; }

        public QuickcheckLademeter lademeter { get; set; }
    }
}