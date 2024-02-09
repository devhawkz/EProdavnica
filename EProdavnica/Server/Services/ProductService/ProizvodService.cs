 
namespace EProdavnica.Server.Services.ProductService;

public class ProizvodService : IProizvodService
{
    private readonly DataContext _context;

    public ProizvodService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<Proizvod>> GetProizvodAsync(int proizvodId)
    {
        var response = new ServiceResponse<Proizvod>();
        var proizvod = await _context.Proizvodi
            .Include(p => p.Varijante)
            .ThenInclude(v => v.TipProizvoda)
            .FirstOrDefaultAsync(p => p.Id == proizvodId);
        
        if(proizvod == null) 
        {
            response.Uspesno = false;
            response.Poruka = "Traženi proizvod ne postoji!";
        }
        else
        {
            response.Podaci = proizvod;
        }
        
        return response;
    }

    public async Task<ServiceResponse<List<Proizvod>>> GetProizvodiAsync()
    {
        var response = new ServiceResponse<List<Proizvod>>
        {
            Podaci = await _context.Proizvodi.Include(p => p.Varijante).ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<List<Proizvod>>> GetProizvodiByKategorijaAsync(string kategorijaUrl)
    {
        var response = new ServiceResponse<List<Proizvod>>
        {
            Podaci = await _context.Proizvodi
                .Where(p => p.Kategorija.Url.ToLower().Equals(kategorijaUrl))
                .Include(p => p.Varijante)
                .ToListAsync()
        };

        return response;
       
    }
}
