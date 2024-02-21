namespace EProdavnica.Server.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> RegistracijaAsync(Korisnik korisnik, string lozinka);

    Task<bool> KorisnikPostojiAsync(string email);

    Task<ServiceResponse<string>> PrijavaAsync(string email, string lozinka);

    Task<ServiceResponse<bool>> PromenaLozinkeAsync(int korisnikId, string novaLozinka);
}
