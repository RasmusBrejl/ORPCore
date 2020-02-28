using Microsoft.EntityFrameworkCore;

namespace ORPCore.Models.Context
{
    public class OrpContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Clearance> Clearances { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Connection> Connections { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Parcel> Parcels { get; set; }

        public DbSet<DiscountCode> DiscountCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=dbs-oapl.database.windows.net;Initial Catalog=db-prod;User ID=dbs-oapl;Password=oceanicFlyAway16");
        }
    }
}