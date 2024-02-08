using EProdavnica.Shared;

namespace EProdavnica.Client.Services.ProductService
{
    public interface IProizvodService
    {
        List<Proizvod> Proizvodi { get; set; }
        Task GetProizvodi();
        Task<ServiceResponse<Proizvod>> GetProizvod(int proizvodId);
    }
}
