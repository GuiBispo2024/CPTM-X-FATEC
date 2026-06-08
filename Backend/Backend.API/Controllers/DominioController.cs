using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/dominios")]
public class DominiosController
    : ControllerBase
{
    private readonly IDominioService _service;

    public DominiosController(
        IDominioService service)
    {
        _service = service;
    }

    [HttpGet("{dominio}")]
    public async Task<IActionResult>
        Get(string dominio)
    {
        var dados =
            await _service.GetAsync(
                dominio);

        return Ok(dados);
    }
}