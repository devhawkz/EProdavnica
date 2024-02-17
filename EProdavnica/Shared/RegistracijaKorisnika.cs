using System.ComponentModel.DataAnnotations;

namespace EProdavnica.Shared;

public class RegistracijaKorisnika
{
    [Required, EmailAddress] //obavezno polje i vrsi se provera da li je uneti mejl u ispravnom formatu
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 6)] // obavezno polje max duzina je 100 a min 6 lozinke 
    public string Lozinka { get; set; } = string.Empty;

    [Compare("Lozinka", ErrorMessage = "Lozinke se ne podudaraju")] // uporedjuje vrednosti polja Lozinka i Potvrda lozinke, ako se ne podudaraju prikazuje se error message (opciono).
    public string PotvrdaLozinke { get; set; } = string.Empty;
}
