namespace EProdavnica.Shared.DTO;

public class RezultatPretrageProizvoda
{
    public List<Proizvod> Proizvodi {get; set; } = new List<Proizvod>();
    public int UkupanBrojStrana { get; set; }
    public int TrenutnaStrana { get; set;}
}
