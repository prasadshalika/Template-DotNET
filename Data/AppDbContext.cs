using template_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace template_dotnet.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<UserAccount> UserAccounts { get; set; }
        public required DbSet<Role> Roles { get; set; } // Add Roles DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure UserAccount -> Role relationship
            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.Role)  // Each UserAccount has one Role
                .WithMany(r => r.Users) // Each Role has many UserAccounts
                .HasForeignKey(u => u.RoleId) // Foreign key in UserAccount
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            // Set schema for all tables
            modelBuilder.HasDefaultSchema("sip");

            base.OnModelCreating(modelBuilder);
        }
    }
}
