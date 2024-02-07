 
namespace EProdavnica.Server.Services.ProductService;

public class ProizvodService : IProizvodService
{
    private readonly DataContext _context;

    public ProizvodService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<Proizvod>>> GetProizvodiAsync()
    {
        var response = new ServiceResponse<List<Proizvod>>
        {
            Data = await _context.Proizvodi.ToListAsync()
        };

        return response;
    }
}
