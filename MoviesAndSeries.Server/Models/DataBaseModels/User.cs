using MoviesAndSeries.Server.Parsers;
using MoviesAndSeries.Server.SerialFan;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class User
	{
		private ulong _timeSpentOnSeries;
		private IEnumerable<PartialSerialFanSerialInfo>? _serialInfo;

		public ulong TimeSpentOnSeries
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

		public int? Id { get; set; }

		public List<Series> Series { get; set; } = new();

		[NotMapped]
		public Dictionary<Series, int> SeriesViewCount { get; set; } = new();

		public async Task<List<Series>> Info()
		{
			_serialInfo = await SerialFanParser.GetPartialInfo();

			foreach (PartialSerialFanSerialInfo seriesInfo in _serialInfo)
			{
				Series series = new(seriesInfo.Name, seriesInfo.KinopoiskRating, seriesInfo.ImdbRating, seriesInfo.StartYear, seriesInfo.EndYear);

				//IAsyncEnumerable<SerialFanSerialInfo> episodes = new SerialFanParser().Parse();

				//ulong duration = default;
				List<Episode> episodesInfo = new();
				for (int i = 0; i < series.Episodes.Count; i++)
				{
					Episode episode = new()
					{
						Duration = (ulong)new Random().Next(40, 60),
					};
					episodesInfo.Add(episode);
				}

				//foreach (SerialFanSeason episode in episodes.Seasons)
				//{
				//	foreach (SerialFanEpisode e in episode.Episodes)
				//	{
				//		duration += e.Duration;
				//		Episode episode1 = new()
				//		{
				//			Duration = duration,
				//		};
				//		episodesInfo.Add(episode1);
				//	}
				//}
				series.Episodes!.AddRange(episodesInfo);

				Series.Add(series);
			}

			return Series;
		}
	}
}