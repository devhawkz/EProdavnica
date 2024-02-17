using System.Security.Cryptography;

namespace EProdavnica.Shared;

public class Korisnik
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public byte[] LozinkaHash { get; set; }

    public byte[] LozinkaSalt { get; set; }

    public DateTime DatumKreiranja { get; set; } = DateTime.Now;
}
