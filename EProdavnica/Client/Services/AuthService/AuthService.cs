
namespace EProdavnica.Client.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<string>> Prijava(PrijavaKorisnika zahtev)
    {
        var rezultat = await _http.PostAsJsonAsync("api/auth/prijava", zahtev);
        return await rezultat.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }

    public async Task<ServiceResponse<bool>> PromenaLozinke(KorisnikPromenaLozinke zahtev)
    {
        var rezultat = await _http.PostAsJsonAsync("api/auth/promena-lozinke", zahtev.Lozinka);
        return await rezultat.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
    }

    public async Task<ServiceResponse<int>> Registracija(RegistracijaKorisnika zahtev)
    {
        var rezultat = await _http.PostAsJsonAsync("api/auth/registracija", zahtev);
        return await rezultat.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }
}
