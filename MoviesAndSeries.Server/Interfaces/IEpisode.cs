namespace MoviesAndSeries.Server.Interfaces
{
	/// <summary>
	/// Unifying interface for all serial episodes
	/// </summary>
	public interface IEpisode
	{
		/// <summary>
		/// Name of the episode
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Duration in seconds
		/// </summary>
		public ulong Duration { get; }
	}
}