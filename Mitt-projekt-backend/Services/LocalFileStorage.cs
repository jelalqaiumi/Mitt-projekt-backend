namespace Mitt_projekt_backend.Services;

public class LocalFileStorage : IFileStorage
{
    private readonly string _uploadRoot;
    private readonly ILogger<LocalFileStorage> _logger;

    public LocalFileStorage(IWebHostEnvironment env, ILogger<LocalFileStorage> logger)
    {
        var webRoot = env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot");
        _uploadRoot = Path.Combine(webRoot, "uploads");
        _logger = logger;

        Directory.CreateDirectory(_uploadRoot);
    }

    public async Task<string> SaveImageAsync(IFormFile file, CancellationToken ct = default)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var fileName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(_uploadRoot, fileName);

        await using var stream = File.Create(fullPath);
        await file.CopyToAsync(stream, ct);

        _logger.LogInformation("Sparade uppladdning {FileName}", fileName);

        return $"/uploads/{fileName}";
    }
}
