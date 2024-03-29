﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class FloorPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title{ get; set; }

        
        public string Image_Path{ get; set; }

        [Required]
        public string Description{ get; set; }

        [Required]
        public int Persons { get; set; }

        [Required]
        public double Price { get; set; }

        public bool isActive { get; set; }

        public string Stat { get; set; }

        public List<CustomizedPlane> CustomizedPlanes { get; set; }

    }
}
