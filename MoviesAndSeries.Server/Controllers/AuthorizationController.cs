using Microsoft.AspNetCore.Mvc;
using MoviesAndSeries.Server.Models.DataBase;
using MoviesAndSeries.Server.Models.DataBaseModels;

namespace MoviesAndSeries.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthorizationController : Controller
	{
		private readonly MovieAndSeriesContext _context;

		public AuthorizationController(MovieAndSeriesContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> AuthorizationAsync(string email, string password)
		{
			User? user = _context.Users!.Where(user => user.Email == email && user.Password == password).FirstOrDefault();

			if (user == null)
			{
				return Empty;
			}
			else
			{
				_ = await _context.SaveChangesAsync();

				return Content($"{user.TimeSpan} {user.TimeSpentOnMovie} {user.TimeSpentOnSeries}");
			}
		}
	}
}