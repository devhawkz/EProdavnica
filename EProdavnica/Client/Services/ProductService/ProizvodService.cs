

namespace EProdavnica.Client.Services.ProductService;

public class ProizvodService : IProizvodService
{
    private readonly HttpClient _http;

    public event Action PromenaProizvoda;

    public List<Proizvod> Proizvodi { get ; set; } = new List<Proizvod>();

    public string Poruka { get; set; } = "Učitavanje proizvoda...";

    public ProizvodService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProizvodi(string? kategorijaUrl = null)
    {
        var rezultat = kategorijaUrl == null ?
            await _http.GetFromJsonAsync<ServiceResponse<List<Proizvod>>>("api/proizvod/preporuceno") :
            await _http.GetFromJsonAsync<ServiceResponse<List<Proizvod>>>($"api/proizvod/kategorija/{kategorijaUrl}");
        
        if (rezultat != null && rezultat.Podaci != null)
            Proizvodi = rezultat.Podaci;

        PromenaProizvoda.Invoke();
    }

    public async Task<ServiceResponse<Proizvod>> GetProizvod(int proizvodId)
    {
        var rezultat =
            await _http.GetFromJsonAsync<ServiceResponse<Proizvod>>($"api/proizvod/{proizvodId}");
        return rezultat;
        
    }

    public async Task PretragaProizvoda(string tekstPretrage)
    {
        var rezultat = await _http.GetFromJsonAsync<ServiceResponse<List<Proizvod>>>($"api/proizvod/pretraga/{tekstPretrage}");

        if(rezultat != null && rezultat.Podaci != null)
        {
            Proizvodi = rezultat.Podaci;
        }

        if(Proizvodi.Count == 0)
        {
            Poruka = "Nijedan takav proizvod nije pronadjen!";
        }

        PromenaProizvoda.Invoke();
    }

    public async Task<List<string>> GetPredloziZaPretraguProizvoda(string tekstPretrage)
    {
        var rezultat = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/proizvod/predlozipretrage/{tekstPretrage}");
         
        return rezultat.Podaci;
    }
}
