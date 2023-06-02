namespace MoviesAndSeries.Server.Interfaces
{
    public interface IParser<TSerial, TSeason, TEpisode>
        where TSerial : ISerialInfo<TSeason, TEpisode>
        where TEpisode : IEpisode
        where TSeason : ISeason<TEpisode>
    {
        IAsyncEnumerable<TSerial> Parse();
    }
}