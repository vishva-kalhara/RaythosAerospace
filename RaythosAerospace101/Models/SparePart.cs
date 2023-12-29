using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class SparePart
    {
        [Key]
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string ManufacturedCountry { get; set; }

        public double Price { get; set; }

        public string Stat { get; set; }

        public int Qty { get; set; }

        public List<SparePartOrder> SparePartOrders { get; set; }

        //[ForeignKey("SPCondition")]
        //public int SPConditionId { get; set; }
        //public SPCondition SPCondition { get; set; }
    }
}
