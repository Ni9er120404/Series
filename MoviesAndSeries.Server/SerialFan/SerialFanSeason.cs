using MoviesAndSeries.Server.Interfaces;
using System.Collections.Immutable;

namespace MoviesAndSeries.Server.SerialFan
{
	public readonly struct SerialFanSeason : ISeason<SerialFanEpisode>
	{
		public string Number { get; }

		public ImmutableArray<SerialFanEpisode> Episodes { get; }

		internal SerialFanSeason(string number, ImmutableArray<SerialFanEpisode> episodes)
		{
			Number = number;
			Episodes = episodes;
		}
	}
}