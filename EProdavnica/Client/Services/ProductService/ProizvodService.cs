
namespace EProdavnica.Client.Services.ProductService;

public class ProizvodService : IProizvodService
{
    private readonly HttpClient _http;

    public List<Proizvod> Proizvodi { get ; set; } = new List<Proizvod>();

    public ProizvodService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProizvodi()
    {
        var rezultat = 
            await _http.GetFromJsonAsync<ServiceResponse<List<Proizvod>>>("api/proizvod");
        if (rezultat != null && rezultat.Podaci != null)
            Proizvodi = rezultat.Podaci;
    }

    public async Task<ServiceResponse<Proizvod>> GetProizvod(int proizvodId)
    {
        var rezultat =
            await _http.GetFromJsonAsync<ServiceResponse<Proizvod>>($"api/proizvod/{proizvodId}");
        return rezultat;
        
    }
}
