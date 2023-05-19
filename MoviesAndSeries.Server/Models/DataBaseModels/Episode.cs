namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class Episode
	{
		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public TimeSpan Duration { get; set; }
	}
}