
namespace EProdavnica.Client.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<int>> Registracija(RegistracijaKorisnika zahtev)
    {
        var rezultat = await _http.PostAsJsonAsync("api/auth/registracija", zahtev);
        return await rezultat.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }
}
