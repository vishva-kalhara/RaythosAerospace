using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class Plane
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Image { get; set; }
        [Required]
        public string Heading1 { get; set; }
        [Required]
        public string Para1 { get; set; }
        [Required]
        public double Distant { get; set; }
        [Required]
        public double Mach { get; set; }
        [Required]
        public double Baggage { get; set; }
        [Required]
        public string Heading2 { get; set; }
        [Required]
        public string Para2 { get; set; }
        [Required]
        public double Price { get; set; }

        [ForeignKey("PlaneStatus")]
        public int PlaneStatusId { get; set; }
        public PlaneStatus PlaneStatus { get; set; }

        public List<CustomizedPlane> CustomizedPlanes { get; set; }
    }
}
