

namespace EProdavnica.Shared.DTO;

public class ProizvodiUKorpiResponse
{
    public int ProizvodId { get; set; }
    public string Naziv { get; set; } = string.Empty;
    public int  TipProizvodaId { get; set; }
    public string TipProizvoda { get; set; } = string.Empty;
    public string SlikaUrl { get; set; } = string.Empty;
    public decimal Cena { get; set; }
    public int Kolicina { get; set; }
}
