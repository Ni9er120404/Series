namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class User
	{
		private TimeSpan _timeSpentOnSeries;
		private TimeSpan _timeSpentOnMovie;

		public User(string lastName, string firstName, string password, string email)
		{
			LastName = lastName;
			FirstName = firstName;
			Password = password;
			Email = email;
			Series = new List<Series>();
			Movies = new List<Movie>();
			SeriesViewCount = new Dictionary<Series, int>();
		}

		public User()
		{
			Series = new List<Series>();
			Movies = new List<Movie>();
			SeriesViewCount = new Dictionary<Series, int>();
		}

		public int? Id { get; set; }

		public string LastName { get; set; } = null!;

		public string FirstName { get; set; } = null!;

		public int Age { get; set; }

		public string? UserName { get; set; }

		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

		public List<Series> Series { get; set; }

		public List<Movie> Movies { get; set; }

		public TimeSpan TimeSpan => TimeSpentOnMovie + TimeSpentOnSeries;

		public TimeSpan TimeSpentOnSeries
		{
			get
			{
				_timeSpentOnSeries = TimeSpan.Zero;

				foreach (Series series in Series)
				{
					foreach (Episode episode in series.Episodes)
					{
						_timeSpentOnSeries += episode.Duration;
					}
				}

				return _timeSpentOnSeries;
			}
		}

		public TimeSpan TimeSpentOnMovie
		{
			get
			{
				_timeSpentOnMovie = TimeSpan.Zero;

				foreach (Movie movie in Movies)
				{
					_timeSpentOnMovie += movie.Duration;
				}

				return _timeSpentOnMovie;
			}
		}

		public void AddSeriesViewCount(Series series, int count)
		{
			if (SeriesViewCount.ContainsKey(series))
			{
				SeriesViewCount[series] += count;
			}
			else
			{
				SeriesViewCount[series] = count;
			}
		}

		public Dictionary<Series, int> SeriesViewCount { get; }
	}
}