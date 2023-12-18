using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class CustomizedPlane
    {
        [Key]
        public int Id { get; set; }

        public DateTime CurrentDate { get; set; }

        public bool IsBasket { get; set; }

        [ForeignKey("Plane")]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }


        [ForeignKey("FloorPlan")]
        public int FloorPlanId { get; set; }
        public FloorPlan FloorPlan { get; set; }


        [ForeignKey("PlaneDesignScheme")]
        public int PlaneDesignSchemeId { get; set; }
        public PlaneDesignScheme PlaneDesignScheme { get; set; }


        [ForeignKey("User")]
        public string UserEmail { get; set; }
        public User User { get; set; }


        [ForeignKey("OverallStatus")]
        public int OverallStatusId { get; set; }
        public OverallStatus OverallStatus { get; set; }
    }
}
