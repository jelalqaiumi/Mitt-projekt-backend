using Mitt_projekt_backend.Models;

namespace Mitt_projekt_backend.Dtos;

public static class MovieMappings
{
	public static MovieResponse ToResponse(this Movie movie) => new()
	{
		Id = movie.Id,
		Title = movie.Title,
		Director = movie.Director,
		Year = movie.Year,
		ImageUrl = movie.ImageUrl,
		CreatedAt = movie.CreatedAt
	};
}