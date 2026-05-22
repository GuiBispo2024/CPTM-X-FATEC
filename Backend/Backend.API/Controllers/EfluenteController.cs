using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/efluentes")]
public class EfluenteController
    : ControllerBase
{
    private readonly IEfluenteService _service;

    public EfluenteController(
        IEfluenteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _service.GetAll()
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        return Ok(
            await _service.GetById(id)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateEfluenteRequest request)
    {
        var response =
            await _service.Create(request);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateEfluenteRequest request)
    {
        await _service.Update(id, request);

        return Ok(new
        {
            message =
                "Efluente atualizado com sucesso"
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        await _service.Delete(id);

        return NoContent();
    }
}