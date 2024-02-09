

namespace EProdavnica.Client.Services.ProductService;

public class ProizvodService : IProizvodService
{
    private readonly HttpClient _http;

    public event Action PromenaKategorije;

    public List<Proizvod> Proizvodi { get ; set; } = new List<Proizvod>();

    public ProizvodService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProizvodi(string? kategorijaUrl = null)
    {
        var rezultat = kategorijaUrl == null ?
            await _http.GetFromJsonAsync<ServiceResponse<List<Proizvod>>>("api/proizvod") :
            await _http.GetFromJsonAsync<ServiceResponse<List<Proizvod>>>($"api/proizvod/kategorija/{kategorijaUrl}");
        
        if (rezultat != null && rezultat.Podaci != null)
            Proizvodi = rezultat.Podaci;

        PromenaKategorije.Invoke();
    }

    public async Task<ServiceResponse<Proizvod>> GetProizvod(int proizvodId)
    {
        var rezultat =
            await _http.GetFromJsonAsync<ServiceResponse<Proizvod>>($"api/proizvod/{proizvodId}");
        return rezultat;
        
    }

}
