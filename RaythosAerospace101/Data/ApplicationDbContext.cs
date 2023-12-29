using Microsoft.EntityFrameworkCore;
using RaythosAerospace101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CustomizedPlane> CustomizedPlanes { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneDesignScheme> PlaneDesignSchemes { get; set; }
        //public DbSet<SPCondition> SPConditions { get; set; }
        public DbSet<SparePartOrder> SparePartOrders { get; set; }
        public DbSet<OverallStatus> OverallStatuses { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<PlaneStatus> PlaneStatuses { get; set; }

        
    }
}
