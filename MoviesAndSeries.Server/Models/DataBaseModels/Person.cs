namespace MoviesAndSeries.Server.Models.DataBaseModels
{
	public class Person
	{
		public int? Id { get; set; }

		public string LastName { get; set; } = null!;

		public string FirstName { get; set; } = null!;

		public int Age { get; set; }
	}
}