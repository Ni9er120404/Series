namespace MoviesAndSeries.Server.Interfaces
{
    internal interface IPartialInfoParser<T> where T : IPartialSerialInfo
    {
        IEnumerable<T> Parse();
    }
}