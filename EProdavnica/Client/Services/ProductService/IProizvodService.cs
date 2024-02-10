using EProdavnica.Shared;

namespace EProdavnica.Client.Services.ProductService;

public interface IProizvodService
{
    event Action PromenaProizvoda;
    
    string Poruka { get; set; }

    List<Proizvod> Proizvodi { get; set; }
    
    Task GetProizvodi(string? kategorijaUrl = null);
    
    Task<ServiceResponse<Proizvod>> GetProizvod(int proizvodId);
    
    Task PretragaProizvoda(string tekstPretrage);
    
    Task<List<string>> GetPredloziZaPretraguProizvoda(string tekstPretrage);

}
