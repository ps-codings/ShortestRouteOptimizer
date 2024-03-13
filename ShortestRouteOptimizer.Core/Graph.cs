using System.Collections.Generic;
using System.Linq;

namespace ShortestRouteOptimizer.Core
{
    public class Graph
    {
        private Dictionary<Node, Dictionary<Node, int>> _nodes;

        public Graph()
        {
            _nodes = new Dictionary<Node, Dictionary<Node, int>>();
        }

        public void AddNode(Node node)
        {
            if (!_nodes.ContainsKey(node))
            {
                _nodes[node] = new Dictionary<Node, int>();
            }
        }

        public void AddEdge(Node from, Node to, int distance, bool isBiDirectional = true)
        {
            this.AddNode(from);
            this.AddNode(to);

            _nodes[from][to] = distance;

            if (isBiDirectional)
            {
                _nodes[to][from] = distance;
            }
        }

        public List<Node> GetNodes()
        {
            return _nodes.Keys.ToList();
        }

        public Dictionary<Node, int> GetNeighborsByNode(Node node)
        {
            return _nodes[node];
        }

    }
}
