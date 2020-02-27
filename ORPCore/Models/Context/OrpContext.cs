using Microsoft.EntityFrameworkCore;

namespace ORP.Models.Context
{
    public class OrpContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Clearance> Clearances { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Connection> Connections { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Parcel> Parcels { get; set; }
    }
}