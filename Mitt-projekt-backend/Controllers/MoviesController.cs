using Microsoft.AspNetCore.Mvc;
using Mitt_projekt_backend.Data;

namespace Mitt_projekt_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(MovieData.Movies);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var movie = MovieData.Movies.FirstOrDefault(m => m.Id == id);
			if (movie == null) return NotFound();
			return Ok(movie);
		}
	}
}