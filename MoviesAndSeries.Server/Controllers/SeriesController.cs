using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models.DataBase;
using MoviesAndSeries.Server.Models.DataBaseModels;

namespace MoviesAndSeries.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeriesController : ControllerBase
	{
		private readonly MovieAndSeriesContext _context;

		public SeriesController(MovieAndSeriesContext context)
		{
			_context = context;
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

			User user = new();
			user.SeriesViewCount.Add(series, quantity);
			_ = _context.Users!.Add(user);

			_ = await _context.SaveChangesAsync();

			return Ok("Добавлен новый сериал");
		}

		[HttpGet]
		public async Task<IActionResult> GetWatchedSeriesTime()
		{
			User? user = await _context.Users!.FirstOrDefaultAsync();

			if (user is null)
			{
				return NotFound();
			}
			else
			{
				return Content($"{user.TimeSpentOnSeries}");
			}
		}
	}
}