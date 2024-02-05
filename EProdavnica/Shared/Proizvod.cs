
namespace EProdavnica.Shared;

public class Proizvod
{
    public int Id { get; set; }
    public string Naziv { get; set; } = string.Empty;
    public string Opis { get; set;} = string.Empty;
    public string SlikaUrl { get; set; } = string.Empty;
    public decimal Cena { get; set; }
}
