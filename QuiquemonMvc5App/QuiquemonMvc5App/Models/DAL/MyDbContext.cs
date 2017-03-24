using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QuiquemonMvc5App.Models.DAL
{
	public class MyDbContext : DbContext
	{
		public MyDbContext() : base("QuiquemonMvc5App") { }

		public DbSet<Logo>     Logos { get; set; }
		public DbSet<User>     Users { get; set; }
		public DbSet<UserTeam> UserTeams { get; set; }
		public DbSet<Team>     Teams { get; set; }
		public DbSet<Payment>  Payments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}