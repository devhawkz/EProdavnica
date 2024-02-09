namespace EProdavnica.Server.Services.ProductService;

public interface IProizvodService
{
    Task<ServiceResponse<List<Proizvod>>> GetProizvodiAsync();
    Task<ServiceResponse<Proizvod>> GetProizvodAsync(int proizvodId);
    Task<ServiceResponse<List<Proizvod>>> GetProizvodiByKategorijaAsync(string kategorijaUrl);
}
