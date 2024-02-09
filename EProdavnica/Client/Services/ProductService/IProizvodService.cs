using EProdavnica.Shared;

namespace EProdavnica.Client.Services.ProductService
{
    public interface IProizvodService
    {
        event Action PromenaKategorije;

        List<Proizvod> Proizvodi { get; set; }
        Task GetProizvodi(string? kategorijaUrl = null);
        Task<ServiceResponse<Proizvod>> GetProizvod(int proizvodId);
    }
}
