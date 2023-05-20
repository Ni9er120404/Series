namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class Series
	{
		public Series()
		{
			People = new List<Person>();
			Episodes = new List<Episode>();
		}

		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public decimal Rating { get; set; }

		public int RatingCount { get; set; }

		public List<Person> People { get; set; }

		public int NumberOfSeasons { get; set; }

		public List<Episode> Episodes { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }
	}
}