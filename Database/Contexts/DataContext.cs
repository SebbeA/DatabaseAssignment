using Database.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
	internal class DataContext : DbContext
	{
		private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sadol\OneDrive\Skrivbord\WIN22\5.-Datalagring\Database_CA\Database\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

		#region constructors

		public DataContext()
		{

		}
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		#endregion

		#region overrides

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseSqlServer(_connectionString);
		}

		#endregion

		public DbSet<IssueEntity> Issues { get; set; } = null!;
		public DbSet<PersonEntity> Persons { get; set; } = null!;
		public DbSet<StatusEntity> Statuses { get; set; } = null!;
	}
}
