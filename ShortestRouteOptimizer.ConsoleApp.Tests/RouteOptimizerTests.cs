using Xunit;
using ShortestRouteOptimizer.Core;
using System.Collections.Generic;

namespace ShortestRouteOptimizer.ConsoleApp.Tests
{
    public class RouteOptimizerTests
    { 
        [Fact]
        public void Initiate_Should_InitiateGraph()
        {
            //Arrange
            int expectedNodes = 9;

            // Act
            var result = RouteOptimizer.Initiate();

            // Assert
            Assert.Equal(expectedNodes, result.GetNodes().Count);
        }
               
    }
}