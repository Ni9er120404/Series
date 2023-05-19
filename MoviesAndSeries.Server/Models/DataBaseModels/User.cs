namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class User
	{
		public User(string lastName, string firstName, string password, string email)
		{
			LastName = lastName;
			FirstName = firstName;
			Password = password;
			Email = email;
		}

		public User() { }

		public int? Id { get; set; }

		public string LastName { get; set; } = null!;

		public string FirstName { get; set; } = null!;

		public int Age { get; set; }

		public string? UserName { get; set; }

		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

		public List<Series> Series { get; set; } = new();

		private TimeSpan _timeSpan;

		public TimeSpan TimeSpan
		{
			get
			{
				return _timeSpan;
			}
			private set
			{
				_timeSpan = TimeSpentOnMovie + TimeSpentOnSeries;
			}
		}

		private TimeSpan _timeSpentOnSeries;

		public TimeSpan TimeSpentOnSeries
		{
			get
			{
				foreach (Series series in Series)
				{
					foreach (Episode episode in series.Episodes)
					{
						_timeSpentOnSeries += episode.Duration;
					}
				}
				return _timeSpentOnSeries;
			}

			set => _timeSpentOnSeries = value;
		}

		public List<Movie> Movies { get; set; } = new();

		private TimeSpan _timeSpentOnMovie;

		public TimeSpan TimeSpentOnMovie
		{
			get
			{
				foreach (Movie movie in Movies)
				{
					_timeSpentOnMovie += movie.Duration;
				}

				return _timeSpentOnMovie;
			}

			set => _timeSpentOnMovie = value;
		}
	}
}