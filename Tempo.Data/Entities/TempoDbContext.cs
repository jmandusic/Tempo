using Microsoft.EntityFrameworkCore;
using Tempo.Data.Entities.Models;
using Tempo.Data.Enums;

namespace Tempo.Data.Entities
{
    public class TempoDbContext : DbContext
    {
        public TempoDbContext(DbContextOptions<TempoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<GymUser> GymUsers { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Notificiation> Notificiations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.Role)
                .HasValue<RegularUser>(Role.Admin)
                .HasValue<Employee>(Role.Employee)
                .HasValue<Admin>(Role.Admin);

            base.OnModelCreating(modelBuilder);
        }
    }
}
