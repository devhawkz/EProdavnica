
namespace EProdavnica.Client.Services.CategoryService;

public class KategorijaService : IKategorijaService
{
    private readonly HttpClient _http;

    public List<Kategorija> Kategorije { get; set; } = new List<Kategorija>();

    public KategorijaService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetKategorije()
    {
        var rezultat = await _http.GetFromJsonAsync<ServiceResponse<List<Kategorija>>>("api/kategorija");
        if(rezultat != null && rezultat.Podaci != null)
        {
            Kategorije = rezultat.Podaci;
        }
    }
}
