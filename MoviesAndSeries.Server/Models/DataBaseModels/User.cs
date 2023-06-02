using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAndSeries.Server.Models.DataBaseModels
{
    public class User
    {
        public static async Task<ulong> CalculateTimeSpentOnSeries(DbSet<Series> seriesSet, DbSet<Episode> episodeSet)
        {
            ulong timeSpentOnSeries = default;

            foreach ((string seriesName, ulong quantity) in SeriesViewCount)
            {
                var series = await seriesSet.FirstOrDefaultAsync(x => x.Name == seriesName);
                if (series is null) continue;
                var episodes = episodeSet.Where(x => x.SeriesId == series.Id);
                foreach (Episode episode in episodes)
                {
                    timeSpentOnSeries += episode.Duration;
                }
                timeSpentOnSeries *= quantity;
            }

            return timeSpentOnSeries;
        }

        public static List<Series> Series { get; set; } = new();

        [NotMapped]
        public static Dictionary<string, ulong> SeriesViewCount { get; set; } = new();
    }
}