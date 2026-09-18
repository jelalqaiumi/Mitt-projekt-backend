using Mitt_projekt_backend.Models;

namespace Mitt_projekt_backend.Repositories;

public interface IMovieRepository
{
    Task<IReadOnlyList<Movie>> GetAllAsync(CancellationToken ct = default);
    Task<Movie?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Movie> AddAsync(Movie movie, CancellationToken ct = default);
    Task<bool> UpdateAsync(Movie movie, CancellationToken ct = default);
}
