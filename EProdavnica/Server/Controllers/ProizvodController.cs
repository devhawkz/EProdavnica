using Microsoft.AspNetCore.Mvc;

namespace EProdavnica.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProizvodController : ControllerBase
{
    private readonly IProizvodService _proizvodiService;

    public ProizvodController(IProizvodService proizvodiService)
    {
        _proizvodiService = proizvodiService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Proizvod>>>> GetProizvodi()
    {
        var rezultat = await _proizvodiService.GetProizvodiAsync();
        return Ok(rezultat);
    }

    [HttpGet("{proizvodId}")]
    public async Task<ActionResult<ServiceResponse<Proizvod>>> GetProizvod(int proizvodId)
    {
        var rezultat = await _proizvodiService.GetProizvodAsync(proizvodId);
        return Ok(rezultat);
    }

    [HttpGet("kategorija/{kategorijaUrl}")]
    public async Task<ActionResult<ServiceResponse<Proizvod>>> GetProizvodiByKategorija(string kategorijaUrl)
    {
        var rezultat = await _proizvodiService.GetProizvodiByKategorijaAsync(kategorijaUrl);
        return Ok(rezultat);
    }

    [HttpGet("pretraga/{tekstPretrage}")]
    public async Task<ActionResult<ServiceResponse<List<Proizvod>>>> PretraziProizvode(string tekstPretrage)
    {
        var rezultat = await _proizvodiService.PretragaProizvodaAsync(tekstPretrage);
        return Ok(rezultat);
    }

    [HttpGet("predlozipretrage/{tekstPretrage}")]
    public async Task<ActionResult<ServiceResponse<List<Proizvod>>>> PredloziZaPretraguProizvoda(string tekstPretrage)
    {
        var rezultat = await _proizvodiService.GetPredloziZaPretraguProizvodaAsync(tekstPretrage);
        return Ok(rezultat);

    }
}
