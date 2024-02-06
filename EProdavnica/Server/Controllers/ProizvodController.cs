using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdavnica.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProizvodController : ControllerBase
{
    private readonly DataContext _context;
    public ProizvodController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult <ServiceResponse<List<Proizvod>>>> GetProizvod()
    {
        var proizvodi = await _context.Proizvodi.ToListAsync();
        var response = new ServiceResponse<List<Proizvod>>()
        {
            Data = proizvodi
        };

        return Ok(response);
    }
}
