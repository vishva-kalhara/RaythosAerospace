using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string Mobile1 { get; set; }

        public string Mobile2 { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }


        [ForeignKey("UserRole")]
        public int RoleId { get; set; }
        public UserRole UserRole { get; set; }


        [ForeignKey("UserStatus")]
        public int UsrStatusId { get; set; }
        public UserStatus UserStatus { get; set; }

        public List<CustomizedPlane> CustomizedPlanes { get; set; }

        public List<SparePartOrder> SparePartOrders { get; set; }
    }
}
