namespace EProdavnica.Server.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> RegistracijaAsync(Korisnik korisnik, string lozinka);

    Task<bool> KorisnikPostojiAsync(string email);
}
