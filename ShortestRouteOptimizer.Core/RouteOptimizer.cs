namespace ShortestRouteOptimizer.Core
{
    public class RouteOptimizer
    {
        public static Graph Initiate()
        {
            Graph graph = new Graph();

            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");
            var nodeD = new Node("D");
            var nodeE = new Node("E");
            var nodeF = new Node("F");
            var nodeG = new Node("G");
            var nodeH = new Node("H");
            var nodeI = new Node("I");

            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddNode(nodeD);
            graph.AddNode(nodeE);
            graph.AddNode(nodeF);
            graph.AddNode(nodeG);
            graph.AddNode(nodeH);
            graph.AddNode(nodeI);

            graph.AddEdge(nodeA, nodeB, 4);
            graph.AddEdge(nodeA, nodeC, 6);

            graph.AddEdge(nodeB, nodeF, 2);

            graph.AddEdge(nodeC, nodeD, 8);

            graph.AddEdge(nodeD, nodeE, 4);
            graph.AddEdge(nodeD, nodeG, 1);

            graph.AddEdge(nodeE, nodeB, 2, false);
            graph.AddEdge(nodeE, nodeF, 3);
            graph.AddEdge(nodeE, nodeI, 8);

            graph.AddEdge(nodeF, nodeG, 4);
            graph.AddEdge(nodeF, nodeH, 6);

            graph.AddEdge(nodeG, nodeH, 5);
            graph.AddEdge(nodeG, nodeI, 5);

            return graph;
        }
    }
}
