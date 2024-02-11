
using Blazored.LocalStorage;

namespace EProdavnica.Client.Services.CartService;

public class KorpaService : IKorpaService
{
    private readonly ILocalStorageService _localStorage;

    public event Action OnChange;

    // ne kreiramo nijedan http poziv pa ga i ne ubrizgavamo
    public KorpaService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task DodajUKorpu(ProizvodUKorpi proizvodUKorpi)
    {
        // ova linija koda pokusava da dobije listu proizvoda iz skladista ciji je kljuc korpa
        var korpa = await _localStorage.GetItemAsync<List<ProizvodUKorpi>>("korpa");

        if (korpa == null)
        {
            // ako ne postoji takvo skladiste kreiraj novo
            korpa = new List<ProizvodUKorpi>();
        }


        // dodaje proizvod u korpu
        korpa.Add(proizvodUKorpi);

        // dodaje vrednosti iz korpe u lokalno skladiste pod kljucem korpa
        await _localStorage.SetItemAsync("korpa", korpa);
    
        OnChange.Invoke();
    }


    public async Task<List<ProizvodUKorpi>> GetProizvodeUKorpi()
    {
        var korpa = await _localStorage.GetItemAsync<List<ProizvodUKorpi>>("korpa");

        if (korpa == null)
        { 
            korpa = new List<ProizvodUKorpi>();
        }

        return korpa;
    }
}
