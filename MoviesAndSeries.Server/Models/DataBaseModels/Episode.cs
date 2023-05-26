using MoviesAndSeries.Server.Interfaces;

namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class Episode : IEpisode
	{
		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public ulong Duration { get; set; }
	}
}