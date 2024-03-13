using Xunit;
using ShortestRouteOptimizer.ConsoleApp;
using ShortestRouteOptimizer.Core;
using System.Collections.Generic;

namespace ShortestRouteOptimizer.ConsoleApp.Tests
{
    public class DijkstraAlgorithmTests
    {
        [Fact]
        public void ShortestPath_Should_ReturnNull_WhenGraphIsNull()
        {
            // Arrange
            Graph graph = null;
            string fromNode = "A";
            string toNode = "D";

            // Act
            var result = DijkstraAlgorithm.ShortestPath(fromNode, toNode, graph);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(null, "B")]
        [InlineData("", "B")]
        [InlineData("A", null)]
        [InlineData("A", "")]
        [InlineData("", "")]
        [InlineData(null, null)]

        public void ShortestPath_Should_ReturnNull_WhenNodesAreNullOrEmpty(string fromNode, string toNode)
        {
            // Arrange
            var graph = RouteOptimizer.Initiate();

            // Act
            var result = DijkstraAlgorithm.ShortestPath(fromNode, toNode, graph);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("A", "A")]
        [InlineData("B", "B")]
        [InlineData("G", "G")]

        public void ShortestPath_Should_ReturnNull_WhenTwoNodesAreEqual(string fromNode, string toNode)
        {
            // Arrange
            var graph = RouteOptimizer.Initiate();

            // Act
            var result = DijkstraAlgorithm.ShortestPath(fromNode, toNode, graph);

            // Assert
            Assert.Null(result);
        }

        public static IEnumerable<object[]> CorrectResultsData = new List<object[]>
        {
            new object[] {"A","B", new List<string> { "A","B"}, 4 },
            new object[] {"A","D", new List<string> { "A","B", "F", "G", "D"}, 11 },
            new object[] {"D","A", new List<string> { "D","E", "B", "A"}, 10 }
        };
        [Theory]
        [MemberData(nameof(CorrectResultsData))]
        public void ShortestPath_Should_ReturnNodesNamesAndDistance_WhenTwoNodesAreValid(string fromNode
            , string toNode
            , List<string> expectedTraversedNodes
            , int expectedDistance)
        {
            // Arrange
            var graph = RouteOptimizer.Initiate();

            // Act
            var result = DijkstraAlgorithm.ShortestPath(fromNode, toNode, graph);

            // Assert
            Assert.Equal(expectedDistance, result.Distance);
            Assert.Equal(expectedTraversedNodes, result.NodeNames);
        }
    }
}