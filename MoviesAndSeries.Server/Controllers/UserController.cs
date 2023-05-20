using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models.DataBase;
using MoviesAndSeries.Server.Models.DataBaseModels;

namespace MoviesAndSeries.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly MovieAndSeriesContext _context;

		public UserController(MovieAndSeriesContext context)
		{
			_context = context;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(string lastName, string firstName, string password, string email)
		{
			if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName) ||
				string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
			{
				return BadRequest("Не все поля заполнены.");
			}

			User user = new()
			{
				LastName = lastName,
				FirstName = firstName,
				Password = password,
				Email = email
			};

			_ = _context.Users!.Add(user);

			_ = await _context.SaveChangesAsync();

			return Ok();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(string email, string password)
		{
			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{
				return BadRequest("Не все поля заполнены.");
			}

			User? user = await _context.Users!.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

			if (user is null)
			{
				return NotFound("Неверные учетные данные.");
			}

			_ = await _context.SaveChangesAsync();

			return Ok($"{user.TimeSpan} {user.TimeSpentOnSeries}");
		}
	}
}