using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public int qty { get; set; }


        //[ForeignKey("SparePart")]
        //public int SparePartId { get; set; }
        //public SparePart SpareParts { get; set; }

    }
}
