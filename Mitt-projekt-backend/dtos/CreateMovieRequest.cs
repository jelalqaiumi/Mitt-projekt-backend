using System.ComponentModel.DataAnnotations;

namespace Mitt_projekt_backend.Dtos;

public class CreateMovieRequest
{
    [Required(ErrorMessage = "Titel är obligatoriskt.")]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Regissör är obligatoriskt.")]
    [StringLength(120)]
    public string Director { get; set; } = string.Empty;

    [Range(1888, 2100, ErrorMessage = "Årtal måste vara mellan 1888 och 2100.")]
    public int Year { get; set; }
}
