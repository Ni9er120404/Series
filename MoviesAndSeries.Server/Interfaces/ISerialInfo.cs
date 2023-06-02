using System.Collections.Immutable;

namespace MoviesAndSeries.Server.Interfaces
{
    /// <summary>
    /// Info about a serial
    /// </summary>
    /// <typeparam name="TEpisode">Specific episode type</typeparam>
    /// <typeparam name="TSeason">Specific season type</typeparam>
    /// <inheritdoc cref="IPartialSerialInfo"/>>
    public interface ISerialInfo<TSeason, TEpisode> : IPartialSerialInfo
        where TEpisode : IEpisode
        where TSeason : ISeason<TEpisode>
    {
        /// <summary>
        /// Description of the serial
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// All the seasons of the serial
        /// </summary>
        public ImmutableArray<TSeason> Seasons { get; }
        /// <summary>
        /// Link to the poster image
        /// </summary>
        public Uri PosterUri { get; }
    }
}