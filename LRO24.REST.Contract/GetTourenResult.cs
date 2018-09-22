using System.Collections.Generic;

namespace LRO24.REST.Contract
{
    public class GetTourenResult
    {
        public List<Tour> items { get; } = new List<Tour>();
    }
}