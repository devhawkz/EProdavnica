using Microsoft.AspNetCore.Http;
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
    public async Task<ActionResult <ServiceResponse<List<Proizvod>>>> GetProizvod()
    {
        var result = await _proizvodiService.GetProizvodiAsync();
        return Ok(result);
    }
}
