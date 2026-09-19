using Mitt_projekt_backend.Data;
using Mitt_projekt_backend.Models;

namespace Mitt_projekt_backend.Repositories;

public class InMemoryMovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies = new();
    private readonly object _gate = new();
    private int _nextId;

    public InMemoryMovieRepository()
    {
        foreach (var movie in MovieData.Movies)
            _movies.Add(Clone(movie));

        _nextId = _movies.Count == 0 ? 1 : _movies.Max(m => m.Id) + 1;
    }

    public Task<IReadOnlyList<Movie>> GetAllAsync(CancellationToken ct = default)
    {
        lock (_gate)
        {
            IReadOnlyList<Movie> snapshot = _movies.Select(Clone).ToList();
            return Task.FromResult(snapshot);
        }
    }

    public Task<Movie?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(movie is null ? null : Clone(movie));
        }
    }

    public Task<Movie> AddAsync(Movie movie, CancellationToken ct = default)
    {
        lock (_gate)
        {
            movie.Id = _nextId++;
            _movies.Add(Clone(movie));
            return Task.FromResult(movie);
        }
    }

    public Task<bool> UpdateAsync(Movie movie, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var index = _movies.FindIndex(m => m.Id == movie.Id);
            if (index == -1) return Task.FromResult(false);

            _movies[index] = Clone(movie);
            return Task.FromResult(true);
        }
    }

    private static Movie Clone(Movie m) => new()
    {
        Id = m.Id,
        Title = m.Title,
        Genre = m.Genre,
        Year = m.Year,
        Rating = m.Rating,
        Description = m.Description,
        ImageUrl = m.ImageUrl,
        CreatedAt = m.CreatedAt
    };
}
