using Microsoft.EntityFrameworkCore;
using Mystro.Models;

namespace Mystro.DataAccess.Data
{
	// add DbContext to configure EF Core
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
				new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
				new Category { Id = 3, Name = "History", DisplayOrder = 3 }
			);

			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					Title = "Fortune of Time",
					Author = "Billy Spark",
					Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.",
					ISBN = "SWD999001",
					ListPrice = 99,
					Price = 90,
					Price50 = 85,
					Price100 = 80,
					CategoryId = 1
				},
				new Product
				{
					Id = 2,
					Title = "Dark Skies",
					Author = "Nancy Hoover",
					Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.",
					ISBN = "CAW777001",
					ListPrice = 40,
					Price = 30,
					Price50 = 25,
					Price100 = 20,
					CategoryId = 1
				},
				new Product
				{
					Id = 3,
					Title = "Vanish in the Sunset",
					Author = "Julian Button",
					Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.",
					ISBN = "RITO555501",
					ListPrice = 55,
					Price = 50,
					Price50 = 45,
					Price100 = 40,
					CategoryId = 2
				},
				new Product
				{
					Id = 4,
					Title = "Mystery of the Old House",
					Author = "Sarah Connors",
					Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam eget felis at lectus pretium facilisis non vel metus.",
					ISBN = "MYST123456",
					ListPrice = 75,
					Price = 65,
					Price50 = 60,
					Price100 = 55,
					CategoryId = 2
				},
				new Product
				{
					Id = 5,
					Title = "The Last Adventure",
					Author = "David Miller",
					Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris.",
					ISBN = "LAST789012",
					ListPrice = 85,
					Price = 80,
					Price50 = 75,
					Price100 = 70,
					CategoryId = 3
				}
			);
		}
	}
}
