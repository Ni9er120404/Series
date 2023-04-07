namespace MoviesAndSeries.Server.Models
{
	public class Movie
	{
		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public List<Person> People { get; set; } = new();

		public DateTime ReleaseDate { get; set; }

		public TimeSpan Duration { get; set; }
	}
}