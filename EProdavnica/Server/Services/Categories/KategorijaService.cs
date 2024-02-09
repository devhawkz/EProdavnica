
namespace EProdavnica.Server.Services.Categories
{
    public class KategorijaService : IKategorijaService
    {
        private readonly DataContext _context;

        public KategorijaService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Kategorija>>> GetKategorijeAsync()
        {
            var response = new ServiceResponse<List<Kategorija>>()
            {
                Podaci = await _context.Kategorije.ToListAsync()
            };

            return response;

        }
    }
}
