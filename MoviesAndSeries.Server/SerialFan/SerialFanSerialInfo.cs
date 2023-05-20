using MoviesAndSeries.Server.Interfaces;
using System.Collections.Immutable;

namespace MoviesAndSeries.Server.SerialFan
{
	public class SerialFanSerialInfo : PartialSerialFanSerialInfo, ISerialInfo<SerialFanSeason, SerialFanEpisode>
	{
		public string Description { get; }

		public Uri PosterUri { get; }

		public ImmutableArray<SerialFanSeason> Seasons { get; }

		internal SerialFanSerialInfo(PartialSerialFanSerialInfo partial, string description, ImmutableArray<SerialFanSeason> seasons, Uri posterUri) : base(partial)
		{
			Description = description;
			Seasons = seasons;
			PosterUri = posterUri;
		}
	}
}