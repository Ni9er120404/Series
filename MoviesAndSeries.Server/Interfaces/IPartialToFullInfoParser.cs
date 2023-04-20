namespace MoviesAndSeries.Server.Interfaces
{
	internal interface IPartialToFullInfoParser<in TPartial, out TSeason, out TFull, out TEpisode>
		where
		TPartial : IPartialSerialInfo
		where
		TEpisode : IEpisode
		where
		TSeason : ISeason<TEpisode>
		where
		TFull : ISerialInfo<TSeason, TEpisode>
	{
		TFull Parse(TPartial partialInfo);
	}
}