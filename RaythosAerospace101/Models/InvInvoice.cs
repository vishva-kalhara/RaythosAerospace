using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class InvInvoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime currDate { get; set; }
        public double price { get; set; }


        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }


        [ForeignKey("User")]
        public string UserEmail { get; set; }
        public User User { get; set; }
    }
}
