using Microsoft.EntityFrameworkCore;
using ORM.Entities;

namespace ORM.CodeFirst
{
	public class TestDBContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-MNIP7P0;Database=TestDB;Integrated Security=true;Encrypt=false;");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
