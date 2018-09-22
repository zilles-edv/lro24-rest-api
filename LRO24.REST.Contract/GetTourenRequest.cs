namespace LRO24.REST.Contract
{
    public class GetTourenRequest
    {
        /// <summary>
        /// Maximale Anzahl an Einträgen (max. 100)
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// ..
        /// </summary>
        public int start { get; set; }

        public string status { get; set; }

        public string changedAfter { get; set; }

        public string orderBy { get; set; }

        public string orderDirection { get; set; }
    }
}