namespace MaSMAUI.Models
{
    public class Series
    {
        public string Name { get; set; }

        public string Rating { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public Uri Poster { get; set; }

        public long WatchCounter { get; set; } = 0;

        public Series(Org.OpenAPITools.Model.Series series)
        {
            Name = series.Name;
            Rating = series.ImdbRating;
            StartDate = series.StartDate;
            EndDate = series.EndDate;
            Poster = new(series.Poster);
        }

        public void AddOneView()
        {
            WatchCounter++;
        }

        public void DeleteOneView()
        {
            if (WatchCounter > 0)
                WatchCounter--;
        }
    }
}
