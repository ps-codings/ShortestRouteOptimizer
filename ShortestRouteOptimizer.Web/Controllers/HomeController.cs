using ShortestRouteOptimizer.Core;
using ShortestRouteOptimizer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortestRouteOptimizer.Web.Controllers
{
    public class HomeController : Controller
    {
        Graph graph;
        public HomeController()
        {
            graph = RouteOptimizer.Initiate();
            ViewBag.AvailableNodes = string.Join(", ", GetAvailableNodesFromGraph());
        }
        public ActionResult Index()
        {
            return View(new Location());
        }

        [HttpPost]
        public ActionResult Index(Location model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // Get available nodes from the graph
                var availableNodes = GetAvailableNodesFromGraph();

                if (!availableNodes.Contains(model.From))
                {
                    ModelState.AddModelError("From", "This is not valid node. Please enter valid FROM");
                    return View(model);
                }

                if (!availableNodes.Contains(model.To))
                {
                    ModelState.AddModelError("To", "This is not valid node. Please enter valid TO");
                    return View(model);
                }

                var shortestPathData = DijkstraAlgorithm.ShortestPath(model.From, model.To, graph);

                if (shortestPathData != null)
                {

                    ViewBag.ShortestPathData = shortestPathData;
                }
               
                return View(model);
            }catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An exception occurred." + ex.Message;
                return View(model);
            }
        }

        private List<string> GetAvailableNodesFromGraph()
        {
            if(graph == null) return new List<string>();

            return graph.GetNodes()
                  .Select(d => d.Name)
                  .ToList();
        }
    }
}