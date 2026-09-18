using Mitt_projekt_backend.Models;

namespace Mitt_projekt_backend.Repositories;

public class InMemoryMovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies = new();
    private readonly object _gate = new();
    private int _nextId = 1;

    public InMemoryMovieRepository()
    {
        Seed(new Movie { Title = "The Matrix", Director = "Lana & Lilly Wachowski", Year = 1999 });
        Seed(new Movie { Title = "Sjunde inseglet", Director = "Ingmar Bergman", Year = 1957 });
        Seed(new Movie { Title = "Parasite", Director = "Bong Joon-ho", Year = 2019 });
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

    private void Seed(Movie movie)
    {
        movie.Id = _nextId++;
        _movies.Add(movie);
    }

    private static Movie Clone(Movie m) => new()
    {
        Id = m.Id,
        Title = m.Title,
        Director = m.Director,
        Year = m.Year,
        ImageUrl = m.ImageUrl,
        CreatedAt = m.CreatedAt
    };
}