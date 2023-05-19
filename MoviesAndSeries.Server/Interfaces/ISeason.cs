using System.Collections.Immutable;

namespace MoviesAndSeries.Server.Interfaces
{
	public interface ISeason<TEpisodes>
		where TEpisodes : IEpisode
	{
		string Number { get; }

		ImmutableArray<TEpisodes> Episodes { get; }
	}
}