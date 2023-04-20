using MoviesAndSeries.Server.Interfaces;

namespace MoviesAndSeries.Server.SerialFan
{
	public readonly struct SerialFanEpisode : IEpisode
	{
		public string Name { get; }

		public ulong Duration { get; }

		internal SerialFanEpisode(string name, ulong duration)
		{
			Name = name;
			Duration = duration;
		}
	}
}