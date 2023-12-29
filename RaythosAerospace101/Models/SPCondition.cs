using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class SPCondition
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        //public List<SparePart> SpareParts { get; set; }
    }
}
