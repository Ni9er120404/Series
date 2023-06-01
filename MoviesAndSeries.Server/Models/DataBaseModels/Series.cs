namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class Series
	{
		public Series(string name, string kinopoiskRating, string imdbRating, string startDate, string endDate)
		{
			Name = name;
			KinopoiskRating = kinopoiskRating;
			ImdbRating = imdbRating;
			StartDate = startDate;
			EndDate = endDate;
		}

		public int? Id { get; set; }

		public string Name { get; set; }

		public string KinopoiskRating { get; set; }

		public string ImdbRating { get; set; }

		public List<Episode>? Episodes { get; set; } = new();

		public string? StartDate { get; set; }

		public string? EndDate { get; set; }

		public string? Poster { get; set; }
	}
}