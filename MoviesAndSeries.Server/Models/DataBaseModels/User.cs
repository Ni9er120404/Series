using MoviesAndSeries.Server.Parsers;
using MoviesAndSeries.Server.SerialFan;

namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class User
	{
		private ulong _timeSpentOnSeries;
		private IEnumerable<PartialSerialFanSerialInfo>? _serialInfo;

		public User()
		{
			SeriesViewCount = new Dictionary<Series, int>();
		}

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

		public List<Series> Series { get; set; } = new();

		public Dictionary<Series, int> SeriesViewCount { get; set; }

		public async Task<List<Series>> Info()
		{
			_serialInfo = await SerialFanParser.GetPartialInfo();

			foreach (PartialSerialFanSerialInfo seriesInfo in _serialInfo)
			{
				Series series = new(seriesInfo.Name, seriesInfo.KinopoiskRating, seriesInfo.ImdbRating, seriesInfo.StartYear, seriesInfo.EndYear);

				SerialFanSerialInfo episodes = new SerialFanPartialToFullParser().Parse(seriesInfo);

				ulong duration = default;
				List<Episode> episodesInfo = new();
				foreach (SerialFanSeason episode in episodes.Seasons)
				{
					foreach (SerialFanEpisode e in episode.Episodes)
					{
						duration += e.Duration;
						Episode episode1 = new()
						{
							Duration = duration,
						};
						episodesInfo.Add(episode1);
					}
				}
				series.Episodes!.AddRange(episodesInfo);

				Series.Add(series);
			}

			return Series;
		}
	}
}