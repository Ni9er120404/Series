using Microsoft.AspNetCore.Authorization;
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

		[HttpPost]
		[Authorize]
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

			string? userName = User.Identity!.Name;

			User? user = await _context.Users!.Include(u => u.Series).FirstOrDefaultAsync(u => u.UserName == userName);

			if (user is null)
			{
				return NotFound("Пользователь не найден.");
			}

			user.Series.Add(series);
			user.AddSeriesViewCount(series, quantity);

			_ = await _context.SaveChangesAsync();

			return Ok("Добавлен новый сериал");
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetWatchedSeriesTime()
		{
			string? userName = User.Identity!.Name;

			User? user = await _context.Users!.Include(u => u.Series).FirstOrDefaultAsync(u => u.UserName == userName);

			if (user is null)
			{
				return NotFound("Пользователь не найден.");
			}

			Dictionary<Series, int> series = user.SeriesViewCount;

			return Ok(series);
		}
	}
}