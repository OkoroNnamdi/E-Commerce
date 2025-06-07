using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DB
{
	public  class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<User> Users { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// CartItem -> Product relationship
			modelBuilder.Entity<CartItem>()
				.HasOne(ci => ci.Product)
				.WithMany()
				.HasForeignKey(ci => ci.ProductId)
				.OnDelete(DeleteBehavior.Cascade);

			// Optional: Add constraints
			modelBuilder.Entity<Product>()
				.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(100);

			modelBuilder.Entity<User>()
				.HasIndex(u => u.Username)
				.IsUnique();

			// Seed Products
			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, Name = "Keyboard", Price = 49.99m, ImageUrl = "/images/keyboard.jpg" },
				new Product { Id = 2, Name = "Mouse", Price = 29.99m, ImageUrl = "/images/mouse.jpg" },
				new Product { Id = 3, Name = "Monitor", Price = 199.99m, ImageUrl = "/images/monitor.jpg" }
			);

			// Seed User with hashed password
			var password = "admin123";
			using var sha256 = System.Security.Cryptography.SHA256.Create();
			var hash = Convert.ToBase64String(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));

			modelBuilder.Entity<User>().HasData(
				new User { Id = 1, Username = "admin", Password = hash }
			);
		}
	}
}
