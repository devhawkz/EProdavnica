using EProdavnica.Shared;

namespace EProdavnica.Client.Services.ProductService;

public interface IProizvodService
{
    event Action PromenaProizvoda;

    string Poruka { get; set; }

    int TrenutnaStrana { get; set; }

    int UkupanBrojStrana { get; set; }

    string PoslednjiTekstPretrage { get; set;}

    List<Proizvod> Proizvodi { get; set; }
    
    Task GetProizvodi(string? kategorijaUrl = null);
    
    Task<ServiceResponse<Proizvod>> GetProizvod(int proizvodId);
    
    Task PretragaProizvoda(string tekstPretrage, int trenutnaStrana);
    
    Task<List<string>> GetPredloziZaPretraguProizvoda(string tekstPretrage);

}
