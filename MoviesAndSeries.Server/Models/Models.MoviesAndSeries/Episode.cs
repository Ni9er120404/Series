namespace MoviesAndSeries.Server.Models.Models.MoviesAndSeries
{
	public class Episode
	{
		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public TimeSpan Duration { get; set; }
	}
}