using Microsoft.EntityFrameworkCore;
using Udemy.Models;

namespace Udemy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SignUpViewModel> Users { get; set; }
        public DbSet<LoginViewModel> Logins { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchasedTopic> PurchasedTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure LoginViewModel as keyless
            modelBuilder.Entity<LoginViewModel>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
