using System.ComponentModel.DataAnnotations;

namespace Mitt_projekt_backend.Dtos;

public class UpdateMovieRequest
{
    [Required(ErrorMessage = "Titel är obligatoriskt.")]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Genre är obligatoriskt.")]
    [StringLength(60)]
    public string Genre { get; set; } = string.Empty;

    [Range(1888, 2100, ErrorMessage = "Årtal måste vara mellan 1888 och 2100.")]
    public int Year { get; set; }

    [Range(0, 10, ErrorMessage = "Betyg måste vara mellan 0 och 10.")]
    public double Rating { get; set; }

    [Required(ErrorMessage = "Beskrivning är obligatoriskt.")]
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;
}