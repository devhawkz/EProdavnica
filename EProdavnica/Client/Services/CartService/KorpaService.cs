
using Blazored.LocalStorage;
using EProdavnica.Shared;
using EProdavnica.Shared.DTO;

namespace EProdavnica.Client.Services.CartService;

public class KorpaService : IKorpaService
{
    private readonly ILocalStorageService _lokalnoSkladiste;
    private readonly HttpClient _http;

    public event Action OnChange;

    // ne kreiramo nijedan http poziv pa ga i ne ubrizgavamo
    public KorpaService(ILocalStorageService lokalnoSkladiste, HttpClient http)
    {
        _lokalnoSkladiste = lokalnoSkladiste;
        _http = http;
    }

    public async Task DodajUKorpu(ProizvodUKorpi proizvodUKorpi)
    {
        // ova linija koda pokusava da dobije listu proizvoda iz skladista ciji je kljuc korpa
        var korpa = await _lokalnoSkladiste.GetItemAsync<List<ProizvodUKorpi>>("korpa");

        if (korpa == null)
        {
            // ako ne postoji takvo skladiste kreiraj novo
            korpa = new List<ProizvodUKorpi>();
        }


        // dodaje proizvod u korpu
        var istiProizvod = korpa.Find(p => p.ProizvodId == proizvodUKorpi.ProizvodId && p.TipProizvodaId == proizvodUKorpi.TipProizvodaId);

        if(istiProizvod == null)
        {
            korpa.Add(proizvodUKorpi);
        }
        else
        {
            istiProizvod.Kolicina += proizvodUKorpi.Kolicina;
        }

        // dodaje vrednosti iz korpe u lokalno skladiste pod kljucem korpa
        await _lokalnoSkladiste.SetItemAsync("korpa", korpa);
    
        OnChange.Invoke();
    }


    public async Task<List<ProizvodUKorpi>> GetStavkeIzKorpe()
    {
        var korpa = await _lokalnoSkladiste.GetItemAsync<List<ProizvodUKorpi>>("korpa");

        if (korpa == null)
        { 
            korpa = new List<ProizvodUKorpi>();
        }

        return korpa;
    }

    public async Task<List<ProizvodiUKorpiResponse>> GetProizvodeIzKorpe()
    {
        // dobijamo vrednosti iz lokalnog skladista u kojem se nalaze proizvodi iz korpe
        var proizvodiIzKorpe = await _lokalnoSkladiste.GetItemAsync<List<ProizvodUKorpi>>("korpa");

        // saljemo zahtev POST ka servisu sa listom proizvoda iz korpe 
        var zahtevKaApiServisu = await _http.PostAsJsonAsync("api/korpa/proizvodi", proizvodiIzKorpe);

        // citamo http odgovor
        var response = await zahtevKaApiServisu.Content.ReadFromJsonAsync<ServiceResponse<List<ProizvodiUKorpiResponse>>>();

        return response.Podaci;
    }

    public async Task IzbrisiProizvodIzKorpe(int proizvodId, int tipProizvodaId)
    {
        // dobijamo vrednosti iz lokalnog skladista u kojem se nalaze proizvodi iz korpe
        var korpa = await _lokalnoSkladiste.GetItemAsync<List<ProizvodUKorpi>>("korpa");

        // ako nema proizvoda u korpi uradi ovo
        if(korpa == null)
        {
            return;
        }

        // pronalazi proizvod sa datim id i id tipa proizvoda
        var proizvodIzKorpe = korpa.Find(p => p.ProizvodId ==  proizvodId && p.TipProizvodaId == tipProizvodaId);

        // ako korpa nije prazna izbrisi navedeni proizvod iz korpe
        if(korpa != null)
        {
            korpa.Remove(proizvodIzKorpe);
        }

        // dodaje vrednosti iz korpe u lokalno skladiste pod kljucem korpa
        await _lokalnoSkladiste.SetItemAsync("korpa", korpa);
        OnChange.Invoke();
    }

    public async Task PromeniKolicinu(ProizvodiUKorpiResponse proizvod)
    {
        // dobijamo vrednosti iz lokalnog skladista u kojem se nalaze proizvodi iz korpe
        var korpa = await _lokalnoSkladiste.GetItemAsync<List<ProizvodUKorpi>>("korpa");

        // ako nema proizvoda u korpi uradi ovo
        if (korpa == null)
        {
            return;
        }

        // pronalazi proizvod sa datim id i id tipa proizvoda
        var proizvodIzKorpe = korpa.Find(p => p.ProizvodId == proizvod.ProizvodId && p.TipProizvodaId == proizvod.TipProizvodaId);

        // ako korpa nije prazna promeni kolicinu navedeni proizvod iz korpe
        if (korpa != null)
        {
            proizvodIzKorpe.Kolicina = proizvod.Kolicina;
        }

        // dodaje vrednosti iz korpe u lokalno skladiste pod kljucem korpa
        await _lokalnoSkladiste.SetItemAsync("korpa", korpa);
    }
}
