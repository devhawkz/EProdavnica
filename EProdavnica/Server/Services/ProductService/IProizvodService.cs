namespace EProdavnica.Server.Services.ProductService;

public interface IProizvodService
{
    Task<ServiceResponse<List<Proizvod>>> GetProizvodiAsync();
}
