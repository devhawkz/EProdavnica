using System.ComponentModel.DataAnnotations;

namespace EProdavnica.Shared;

public class PrijavaKorisnika
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Lozinka { get; set; } = string.Empty;
}
