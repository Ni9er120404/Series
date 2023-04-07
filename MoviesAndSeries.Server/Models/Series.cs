namespace MoviesAndSeries.Server.Models
{
	public class Series
	{
		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public List<Person> People { get; set; } = new();

		public int NumberOfSeasons { get; set; }

		public List<Episode> Episodes { get; set; } = new();

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
	}
}