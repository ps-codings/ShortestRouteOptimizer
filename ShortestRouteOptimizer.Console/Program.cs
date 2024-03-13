using System;
using System.Collections.Generic;
using System.Linq;
using ShortestRouteOptimizer.Core;

namespace ShortestRouteOptimizer.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isAppEnd = false;

            // Display welcome message.
            DisplayMessageOnConsole("*** Welcome to Shortest Route Optimizer Console App ***\n",
               ConsoleColor.Green);

            DisplayMessageOnConsole("--------------------------------------------------------\n");

            // Initiate graph and nodes
            var graph = RouteOptimizer.Initiate();

            if (graph == null)
            {
                DisplayMessageOnConsole("\n Graph is null\n");
                return;
            }

            // Get available nodes from the graph
            var availableNodes = GetAvailableNodesFromGraph(graph);

            if (availableNodes.Count == 0)
            {
                DisplayMessageOnConsole("\n Node count is zero\n");
                return;
            }

            // Display valid nodes
            DisplayMessageOnConsole($"\n!!! Valid nodes ({JoinList(availableNodes) }) for input !!!\n",
                            ConsoleColor.Yellow);

            while (!isAppEnd)
            {
                string fromNodeName = string.Empty,
                       toNodeName = string.Empty;

                // Ask the user to enter FROM node
                fromNodeName = GetUserNodeInput("FROM", availableNodes);

                // Ask the user to enter TO node
                toNodeName = GetUserNodeInput("TO", availableNodes);

                try
                {
                    // Calculate the shortest route 
                    var shortPathData = DijkstraAlgorithm.ShortestPath(fromNodeName, toNodeName, graph);

                    if (shortPathData == null)
                    {
                        DisplayMessageOnConsole("\nSome error occurred while calculating shortest route. Close the application and try again.\n");
                        return;
                    }

                    // Display calculated shortest route result
                    DisplayMessageOnConsole($"\nfromNodeName = “{fromNodeName}”, " +
                        $"toNodeName = ”{toNodeName}”:" +
                        $" {JoinList(shortPathData.NodeNames)}");

                    DisplayMessageOnConsole($"\nTotal Distance: {shortPathData.Distance}\n");

                }
                catch (Exception ex)
                {
                    DisplayMessageOnConsole("\nAn exception occurred. \n - Details: " + ex.Message,
                        ConsoleColor.Red);
                }

                DisplayMessageOnConsole("\n------------------------\n");

                // Wait for the user to respond before closing.
                DisplayMessageOnConsole("\nPress 'n' and Enter to close the application, or press any other key and Enter to continue: ");

                if (Console.ReadLine() == "n") isAppEnd = true;

                DisplayMessageOnConsole("\n");
            }
            return;
        }

        private static string GetUserNodeInput(string nodeType, List<string> availableNodes)
        {
            string nodeName;
            // Ask the user to enter node
            DisplayMessageOnConsole($"\nType {nodeType} node, and then press Enter: ");
            nodeName = Console.ReadLine();

            while (!availableNodes.Exists(d => d.Equals(nodeName)))
            {
                DisplayMessageOnConsole($"This is not valid node. Please enter {nodeType} node: ");
                nodeName = Console.ReadLine();
            }

            return nodeName;
        }

        private static List<string> GetAvailableNodesFromGraph(Graph graph)
        {
            return graph.GetNodes()
                  .Select(d => d.Name)
                  .ToList();
        }

        private static string JoinList(List<string> list)
        {
            if (list.Count == 0) return string.Empty;

            return string.Join(",", list);
        }

        private static void DisplayMessageOnConsole(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            Console.Write(message);

            Console.ResetColor();
        }
    }
}
