using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class SparePartOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime currentDateTime { get; set; }

        [ForeignKey("SparePart")]
        public int SparePartId { get; set; }
        public SparePart SparePart { get; set; }


        [ForeignKey("User")]
        public string UserEmail { get; set; }
        public User User { get; set; }


    }
}
