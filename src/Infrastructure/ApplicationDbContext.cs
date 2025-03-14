using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User and Cart (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            // Product and ProductTranslations (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Translations)
                .WithOne(pt => pt.Product)
                .HasForeignKey(pt => pt.ProductId);

            // Cart and CartItems (One-to-Many)
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            // CartItem and Product (Many-to-One)
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            // ProductTranslation unique index
            modelBuilder.Entity<ProductTranslation>()
                .HasIndex(pt => new { pt.ProductId, pt.LanguageCode })
                .IsUnique();

            // Indexes for unique IDs
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();

            modelBuilder.Entity<Cart>()
                .HasIndex(c => c.Id)
                .IsUnique();

            modelBuilder.Entity<CartItem>()
                .HasIndex(ci => ci.Id)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Id)
                .IsUnique();

            modelBuilder.Entity<ProductTranslation>()
                .HasIndex(pt => pt.Id)
                .IsUnique();
        }
    }
}
