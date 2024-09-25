using JobBoardBackend.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore;

namespace JobBoardBackend.Entities
{
    public class JobBoardDbContext : DbContext
    {
        private readonly string _connectionString = "Data Source=DESKTOP-NJUV7II\\SQLEXPRESS;Initial Catalog=JobBoardDB;Integrated Security=True;Trust Server Certificate=True";
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<UserLogin>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<UserLogin>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<UserLogin>()
               .Property(u => u.RoleId)
               .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
