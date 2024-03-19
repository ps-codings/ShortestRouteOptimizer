using Xunit;
using ShortestRouteOptimizer.Core;
using System.Xml.Linq;

namespace ShortestRouteOptimizer.Core.Tests
{
    public class GraphTests
    {
        [Fact]
        public void AddNode_Should_InsertNodeCorrectly()
        {
            //Arrange
            var graph = new Graph();
            var nodeA = new Node("A");
            var nodeB = new Node("B");

            // Act
            graph.AddEdge(nodeA, nodeB, 4);

            // Assert
            Assert.True(graph.GetNodes().Count == 2);
        }

        [Fact]
        public void AddNode_ShouldNot_InsertSameNodeTwice()
        {
            //Arrange
            var graph = new Graph();
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");

            // Act
            graph.AddEdge(nodeA, nodeB, 4);
            graph.AddEdge(nodeA, nodeC, 6);

            // Assert
            Assert.True(graph.GetNodes().Count == 3);
        }

        [Fact]
        public void AddEdge_Should_AddEdgeCorrectly()
        {
            //Arrange
            var graph = new Graph();
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");

            // Act
            graph.AddEdge(nodeA, nodeB, 4);
            graph.AddEdge(nodeA, nodeC, 6);

            // Assert
            Assert.Equal(2, graph.GetNeighborsByNode(nodeA).Count);
        }

        [Fact]
        public void AddEdge_ShouldNot_AddEdgeBiDirectional()
        {
            //Arrange
            var graph = new Graph();
            var nodeA = new Node("A");
            var nodeB = new Node("B");

            // Act
            graph.AddEdge(nodeA, nodeB, 4, false);

            // Assert
            Assert.True(graph.GetNeighborsByNode(nodeA).Count == 1);
            Assert.Empty(graph.GetNeighborsByNode(nodeB));
        }

    }
}