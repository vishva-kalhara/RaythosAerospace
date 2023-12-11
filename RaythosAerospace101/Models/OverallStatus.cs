using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class OverallStatus
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }

        public List<CustomizedPlane> CustomizedPlanes { get; set; }

    }
}
