using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class UserStatus
    {
        [Key]
        public int UsrStatusId { get; set; }

        public string UsrStatusValue { get; set; }

        public List<User> Users { get; set; }
    }
}
