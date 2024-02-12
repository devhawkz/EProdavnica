using EProdavnica.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdavnica.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KorpaController : ControllerBase
{
    private readonly IKorpaService _korpaService;

    public KorpaController(IKorpaService korpaService)
    {
        _korpaService = korpaService;
    }

    [HttpPost("proizvodi")] // parametar proizvodiIzKorpe se ne dobija iz rute vec iz request body-a to i oznacava atribut [FromBody] 
    public async Task<ActionResult<ServiceResponse<ProizvodiUKorpiResponse>>> GetProizvodeIzKorpe([FromBody]List<ProizvodUKorpi> proizvodiIzKorpe)
    {
        var rezultat = await _korpaService.GetProizvodeIzKorpeAsync(proizvodiIzKorpe);
        return Ok(rezultat);
    }
}
