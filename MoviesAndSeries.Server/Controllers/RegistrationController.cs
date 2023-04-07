﻿using Microsoft.AspNetCore.Mvc;
using MoviesAndSeries.Server.Models;
using MoviesAndSeries.Server.Models.DataBase;

namespace MoviesAndSeries.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegistrationController : Controller
	{
		private readonly MovieAndSeriesContext _context;

		public RegistrationController(MovieAndSeriesContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task CreateUser(string lastName, string firstName, string password, string email)
		{
			User user = new(lastName, firstName, password, email);

			_ = _context.Add(user);
			_ = await _context.SaveChangesAsync();
		}
	}
}