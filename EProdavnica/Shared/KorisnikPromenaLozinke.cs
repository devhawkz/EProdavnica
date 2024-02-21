using System.ComponentModel.DataAnnotations;

namespace EProdavnica.Shared;

public class KorisnikPromenaLozinke
{
    [Required, StringLength(100, MinimumLength = 6)]
    public string Lozinka { get; set; } = string.Empty;
    [Compare("Lozinka", ErrorMessage = "Lozinke se ne podudaraju.")]
    public string PotvrdaLozinke { get; set; } = string.Empty;
}
