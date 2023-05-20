using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAndSeries.Server.Models.DataBase;
using MoviesAndSeries.Server.Models.DataBaseModels;

namespace MoviesAndSeries.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize] // Добавляем атрибут [Authorize] для требования аутентификации
	public class WatchedSeriesController : ControllerBase
	{
		private readonly MovieAndSeriesContext _context;

		public WatchedSeriesController(MovieAndSeriesContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetWatchedSeries()
		{
			int userId = int.Parse(User.Identity!.Name!);

			User user = _context.Users!.FirstOrDefault(u => u.Id == userId)!;

			if (user is null)
			{
				return NotFound();
			}

			List<Series> watchedSeries = user.Series.ToList();

			return Ok(watchedSeries);
		}
	}
}