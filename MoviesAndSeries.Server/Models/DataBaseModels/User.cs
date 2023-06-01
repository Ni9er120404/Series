using MoviesAndSeries.Server.SerialFan;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class User
	{
		private static ulong _timeSpentOnSeries;
		private static readonly IEnumerable<PartialSerialFanSerialInfo>? _serialInfo;

		public static ulong TimeSpentOnSeries
		{
			get
			{
				_timeSpentOnSeries = default;

				foreach (Series series in SeriesViewCount.Keys)
				{
					foreach (Episode episode in series.Episodes!)
					{
						_timeSpentOnSeries += episode.Duration;
					}
				}

				return _timeSpentOnSeries;
			}
		}

		public static List<Series> Series { get; set; } = new();

		[NotMapped]
		public static Dictionary<Series, int> SeriesViewCount { get; set; } = new();

		//public static async Task<List<Series>> Info()
		//{
		//	_serialInfo = await SerialFanParser.GetPartialInfo();
		//	MovieAndSeriesContext context = new();

		//	foreach (PartialSerialFanSerialInfo seriesInfo in _serialInfo)
		//	{
		//		Series series = new(seriesInfo.Name, seriesInfo.KinopoiskRating, seriesInfo.ImdbRating, seriesInfo.StartYear, seriesInfo.EndYear);
		//		//_ = new SerialFanParser().Parse();
		//		List<Episode> episodesInfo = new();
		//		for (int i = 0; i < 10; i++)
		//		{
		//			Episode episode = new()
		//			{
		//				Duration = (ulong)new Random().Next(40, 60),
		//			};
		//			episodesInfo.Add(episode);
		//		}

		//		//foreach (var episode in episodes.Seasons)
		//		//{
		//		//	foreach (SerialFanEpisode e in episode.Episodes)
		//		//	{
		//		//		duration += e.Duration;
		//		//		Episode episode1 = new()
		//		//		{
		//		//			Duration = duration,
		//		//		};
		//		//		episodesInfo.Add(episode1);
		//		//	}
		//		//}
		//		series.Episodes!.AddRange(episodesInfo);

		//		Series.Add(series);
		//	}
		//	context.Series.AddRange(Series);
		//	_ = context.SaveChanges();
		//	context.Dispose();
		//	return Series;
		//}
	}
}