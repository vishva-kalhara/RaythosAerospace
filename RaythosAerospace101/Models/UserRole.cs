using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        
        [Required]
        public string RoleValue { get; set; }

        public List<User> Users { get; set; }
    }
}
