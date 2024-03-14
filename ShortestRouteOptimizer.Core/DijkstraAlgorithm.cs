using ShortestRouteOptimizer.Core.Dtos;
using System.Collections.Generic;

namespace ShortestRouteOptimizer.Core
{
    public class DijkstraAlgorithm
    {
        public static ShortestPathData ShortestPath(string fromNodeName, string toNodeName,
            Graph graph)
        {
            if (graph is null)
                return null;

            if (string.IsNullOrEmpty(fromNodeName))
                return null;

            if (string.IsNullOrEmpty(toNodeName))
                return null;

            //if (fromNodeName == toNodeName)
            //    return null;

            var fromNode = new Node(fromNodeName);
            var toNode = new Node(toNodeName);

            var distances = new Dictionary<string, int>();
            var visitedNodes = new Dictionary<string, Node>();
            var nodesList = new List<Node>();

            foreach (var node in graph.GetNodes())
            {
                distances[node.Name] = (node.Name == fromNode.Name) ? 0 : int.MaxValue;
                visitedNodes[node.Name] = null;

                nodesList.Add(node);
            }

            while (nodesList.Count != 0)
            {
                nodesList.Sort((x, y) => distances[x.Name] - distances[y.Name]);

                var currentNode = nodesList[0];
                nodesList.Remove(currentNode);

                if (currentNode.Name == toNode.Name)
                {
                    var path = new List<string>();
                    while (currentNode != null
                        && visitedNodes.ContainsKey(currentNode.Name))
                    {
                        path.Add(currentNode.Name);
                        currentNode = visitedNodes[currentNode.Name];
                    }
                    path.Reverse();

                    // Return 
                    return new ShortestPathData
                    {
                        NodeNames = path,
                        Distance = distances[toNode.Name],
                    };
                }

                if (distances[currentNode.Name] == int.MaxValue)
                {
                    break;
                }

                var neighborNodes = graph.GetNeighborsByNode(currentNode);

                foreach (var neighborNode in neighborNodes)
                {
                    var tempDistance = distances[currentNode.Name] + neighborNode.Value;
                    if (tempDistance < distances[neighborNode.Key.Name])
                    {
                        distances[neighborNode.Key.Name] = tempDistance;
                        visitedNodes[neighborNode.Key.Name] = currentNode;
                    }
                }
            }

            return null;
        }
    }
}
