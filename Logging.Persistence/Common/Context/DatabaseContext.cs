using Logging.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Logging.Persistence.Common.Context
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options: options)
		{
			// TODO
			Database.EnsureCreated();
		}

		// **********
		public DbSet<Log> Logs { get; set; }
		// **********

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
