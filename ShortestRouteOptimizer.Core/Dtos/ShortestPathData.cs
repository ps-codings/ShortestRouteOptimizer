using System.Collections.Generic;

namespace ShortestRouteOptimizer.Core.Dtos
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; }
        public int Distance { get; set; }
    }
}
