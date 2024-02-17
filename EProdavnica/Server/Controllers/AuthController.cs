using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdavnica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("registracija")]
        public async Task<ActionResult<ServiceResponse<int>>> Registracija(RegistracijaKorisnika zahtev)
        {
            var response = await _authService.RegistracijaAsync(
                new Korisnik 
            { 
                Email = zahtev.Email 
            }, 
            zahtev.Lozinka);

            // proverava da li je korisnik sa tom mejl adresom vec kreiran
            if(!response.Uspesno)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
