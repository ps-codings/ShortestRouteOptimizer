using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShortestRouteOptimizer.Web.Models
{
    public class Location
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
    }
}