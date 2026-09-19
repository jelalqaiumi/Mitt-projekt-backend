namespace Mitt_projekt_backend.Dtos;

public class MovieResponse
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Genre { get; init; } = string.Empty;
    public int Year { get; init; }
    public double Rating { get; init; }
    public string Description { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
    public DateTime CreatedAt { get; init; }
}