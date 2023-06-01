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

			_ = await _context.SaveChangesAsync();

			return Ok("Добавлен новый сериал");
		}

		[HttpGet]
		public async Task<IActionResult> GetWatchedSeriesTime()
		{
			return Ok($"{Models.DataBaseModels.User.TimeSpentOnSeries}");
		}

		[HttpGet("list/{start}, {amount}")]
		public async Task<IEnumerable<Series>> GetAllSeries(int start, int amount)
		{
			return _context.Series!.OrderBy(x => x.Id).Skip(start).Take(amount);
		}

		private async Task<List<Series>> Info()
		{
			IEnumerable<SerialFanSerialInfo> info = new SerialFanParser()
				.Parse()
				.ToBlockingEnumerable()
				.Take(10);

			List<Series> serials = new(10);

			foreach (SerialFanSerialInfo? seriesInfo in info)
			{
				Series series = new(seriesInfo.Name, seriesInfo.KinopoiskRating, seriesInfo.ImdbRating, seriesInfo.StartYear, seriesInfo.EndYear)
				{
					Poster = seriesInfo.PosterUri.ToString(),
				};
				series.Episodes!.AddRange(seriesInfo.Seasons.SelectMany(season => season.Episodes.AsEnumerable().Select(episode => new Episode()
				{
					Name = episode.Name,
					Duration = episode.Duration
				})));
				serials.Add(series);
			}

			return serials;
		}
	}
}