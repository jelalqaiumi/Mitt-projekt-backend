using Microsoft.AspNetCore.Mvc;
using Mitt_projekt_backend.Dtos;
using Mitt_projekt_backend.Models;
using Mitt_projekt_backend.Repositories;

namespace Mitt_projekt_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MoviesController : ControllerBase
{
	private readonly IMovieRepository _repository;
	private readonly ILogger<MoviesController> _logger;

	public MoviesController(IMovieRepository repository, ILogger<MoviesController> logger)
	{
		_repository = repository;
		_logger = logger;
	}

	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<MovieResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<IEnumerable<MovieResponse>>> GetAll(CancellationToken ct)
	{
		var movies = await _repository.GetAllAsync(ct);
		return Ok(movies.Select(m => m.ToResponse()));
	}

	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<MovieResponse>> GetById(int id, CancellationToken ct)
	{
		var movie = await _repository.GetByIdAsync(id, ct);

		if (movie is null)
			return NotFound();

		return Ok(movie.ToResponse());
	}

	[HttpPost]
	[ProducesResponseType(typeof(MovieResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<MovieResponse>> Create(
		CreateMovieRequest request,
		CancellationToken ct)
	{
		var movie = new Movie
		{
			Title = request.Title.Trim(),
			Genre = request.Genre.Trim(),
			Year = request.Year,
			Rating = request.Rating,
			Description = request.Description.Trim()
		};

		var created = await _repository.AddAsync(movie, ct);

		_logger.LogInformation("Created movie {MovieId}", created.Id);

		return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToResponse());
	}

	[HttpPut("{id:int}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Update(
		int id,
		UpdateMovieRequest request,
		CancellationToken ct)
	{
		var existing = await _repository.GetByIdAsync(id, ct);

		if (existing is null)
			return NotFound();

		existing.Title = request.Title.Trim();
		existing.Genre = request.Genre.Trim();
		existing.Year = request.Year;
		existing.Rating = request.Rating;
		existing.Description = request.Description.Trim();

		await _repository.UpdateAsync(existing, ct);

		_logger.LogInformation("Updated movie {MovieId}", id);

		return NoContent();
	}
}