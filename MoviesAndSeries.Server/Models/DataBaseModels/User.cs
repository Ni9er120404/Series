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

				foreach ((Series series, ulong quantity) in SeriesViewCount)
				{
					foreach (Episode episode in series.Episodes!)
					{
						_timeSpentOnSeries += episode.Duration;
					}
					_timeSpentOnSeries *= quantity;
				}

				return _timeSpentOnSeries;
			}
		}

		public static List<Series> Series { get; set; } = new();

		[NotMapped]
		public static Dictionary<Series, ulong> SeriesViewCount { get; set; } = new();
	}
}