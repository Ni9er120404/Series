using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models.DataBaseModels;

namespace MoviesAndSeries.Server.Models.DataBase
{
	public class MovieAndSeriesContext : DbContext
	{
		public MovieAndSeriesContext(DbContextOptions options) : base(options)
		{
			//_ = Database.EnsureDeleted();
			_ = Database.EnsureCreated();
		}
		public MovieAndSeriesContext() { }
		public DbSet<Episode>? Episodes { get; set; }

		public DbSet<Series>? Series { get; set; }
	}
}