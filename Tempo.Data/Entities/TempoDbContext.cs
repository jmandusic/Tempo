using Gymify.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Data.Entities
{
    public class TempoDbContext : DbContext
    {
        public TempoDbContext(DbContextOptions<TempoDbContext> options) : base(options)
        {
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<GymUser> GymUsers { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Notificiation> Notificiations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
