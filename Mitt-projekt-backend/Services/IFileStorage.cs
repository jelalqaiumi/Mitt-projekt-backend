namespace Mitt_projekt_backend.Services;

public interface IFileStorage
{
    Task<string> SaveImageAsync(IFormFile file, CancellationToken ct = default);
}
