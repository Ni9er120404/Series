namespace MoviesAndSeries.Server.Models.DataBaseModels
{
    public class Movie
    {
        public Movie()
        {
            People = new List<Person>();
        }

        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public List<Person> People { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Duration { get; set; }
    }
}