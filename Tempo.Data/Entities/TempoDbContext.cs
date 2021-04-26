using Microsoft.EntityFrameworkCore;
using Tempo.Data.Entities.Models;
using Tempo.Data.Enums;
using Tempo.Data.Seed;

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
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.Role)
                .HasValue<Admin>(Role.Admin)
                .HasValue<Employee>(Role.Employee)
                .HasValue<RegularUser>(Role.RegularUser);

            DatabaseSeed.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
