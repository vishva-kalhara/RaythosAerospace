using RaythosAerospace101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.ViewModels
{
    public class FloorPlanDesignScheme
    {
        public List<FloorPlan> FloorPlans { get; set; }
        public List<PlaneDesignScheme> planeDesignSchemes { get; set; }
        public Plane plane { get; set; }
    }
}
