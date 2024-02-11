using EProdavnica.Shared.DTO;

namespace EProdavnica.Server.Services.ProductService;

public interface IProizvodService
{
    Task<ServiceResponse<List<Proizvod>>> GetProizvodiAsync();
    
    Task<ServiceResponse<Proizvod>> GetProizvodAsync(int proizvodId);
    
    Task<ServiceResponse<List<Proizvod>>> GetProizvodiByKategorijaAsync(string kategorijaUrl);
    
    Task<ServiceResponse<RezultatPretrageProizvoda>> PretragaProizvodaAsync(string tekstPretrage, int trenutnaStrana);
    
    Task<ServiceResponse<List<string>>> GetPredloziZaPretraguProizvodaAsync(string tekstPretrage);

    Task<ServiceResponse<List<Proizvod>>> GetPreporuceneProizvodeAsync();

}
