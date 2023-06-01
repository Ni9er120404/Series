using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models.DataBase;
using MoviesAndSeries.Server.Models.DataBaseModels;
using MoviesAndSeries.Server.Parsers;
using MoviesAndSeries.Server.SerialFan;

namespace MoviesAndSeries.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeriesController : ControllerBase
	{
		private readonly MovieAndSeriesContext _context;
		private static readonly IEnumerable<PartialSerialFanSerialInfo>? _serialInfo;
		public SeriesController(MovieAndSeriesContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Post()
		{

			await _context.Series!.AddRangeAsync(await Info());

			_ = await _context.SaveChangesAsync();


			return Ok();
		}

		[HttpPost("{name}, {quantity}")]
		public async Task<IActionResult> AddSeries(string name, int quantity)
		{
			if (string.IsNullOrEmpty(name))
			{
				return BadRequest("Пустое поле.");
			}

			Series? series = await _context.Series!.FirstOrDefaultAsync(s => s.Name == name);
			if (series is null)
			{
				return NotFound("Не существует такого сериала.");
			}
			IQueryable<Episode> episodes = _context.Episodes.Where(x => x.SeriesId == series.Id);
			series.Episodes = episodes.ToList();
			Models.DataBaseModels.User.SeriesViewCount.Add(series, quantity);
			//_context.Users!.FirstOrDefault()!.SeriesViewCount.Add(seriesInfo, quantity);
			//_ = _context.Users!.Add(user);

			_ = await _context.SaveChangesAsync();

			return Ok("Добавлен новый сериал");
		}

		[HttpGet]
		public async Task<IActionResult> GetWatchedSeriesTime()
		{
			//User? user = await _context.Users!.FirstOrDefaultAsync();

			//if (user is null)
			//{
			//	return NotFound();
			//}
			//else
			//{
			return Ok($"{Models.DataBaseModels.User.TimeSpentOnSeries}");
			//}
		}
		//[HttpPost]
		private async Task<List<Series>> Info()
		{
			IEnumerable<SerialFanSerialInfo> info = new SerialFanParser()
				.Parse()
				.ToBlockingEnumerable()
				.Take(10);

			List<Series> serials = new(10);

			foreach (SerialFanSerialInfo? seriesInfo in info)
			{
				Series series = new(seriesInfo.Name, seriesInfo.KinopoiskRating, seriesInfo.ImdbRating, seriesInfo.StartYear, seriesInfo.EndYear);
				series.Episodes!.AddRange(seriesInfo.Seasons.SelectMany(season => season.Episodes.AsEnumerable().Select(episode => new Episode()
				{
					Name = episode.Name,
					Duration = episode.Duration
				})));
				serials.Add(series);
			}

			return serials;

			//_serialInfo = await SerialFanParser.GetPartialInfo();
			//List<Series> result = new List<Series>();
			//foreach (PartialSerialFanSerialInfo seriesInfo in _serialInfo)
			//{
			//	Series seriesInfo = new(seriesInfo.Name, seriesInfo.KinopoiskRating, seriesInfo.ImdbRating, seriesInfo.StartYear, seriesInfo.EndYear);
			//	//_ = new SerialFanParser().Parse();
			//	List<Episode> episodesInfo = new();
			//	for (int i = 0; i < 10; i++)
			//	{
			//		Episode episode = new()
			//		{
			//			Duration = (ulong)new Random().Next(40, 60),
			//		};
			//		episodesInfo.Add(episode);
			//	}

			//	//foreach (var episode in episodes.Seasons)
			//	//{
			//	//	foreach (SerialFanEpisode e in episode.Episodes)
			//	//	{
			//	//		duration += e.Duration;
			//	//		Episode episode1 = new()
			//	//		{
			//	//			Duration = duration,
			//	//		};
			//	//		episodesInfo.Add(episode1);
			//	//	}
			//	//}
			//	seriesInfo.Episodes!.AddRange(episodesInfo);

			//	_ = _context.Series.Add(seriesInfo);
			//}
			//_context.Series.AddRange(result);
			//_ = _context.SaveChanges();
			//return _context.Series.ToList();
		}
	}
}