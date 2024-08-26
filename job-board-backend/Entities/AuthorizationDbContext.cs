using Microsoft.EntityFrameworkCore;

namespace JobBoardBackend.Entities
{
    public class AuthorizationDbContext : DbContext
    {
        private readonly string _connectionString = "Data Source=DESKTOP-NJUV7II\\SQLEXPRESS;Initial Catalog=JobBoardDB;Integrated Security=True;Trust Server Certificate=True";
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(u => u.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
