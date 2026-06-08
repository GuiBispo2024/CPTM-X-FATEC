using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/efluente")]
public class EfluenteController : ControllerBase
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
        var result =
            await _service.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{codigoMeioAmbienteCptm}")]
    public async Task<IActionResult> GetById(
        string codigoMeioAmbienteCptm)
    {
        var result =
            await _service.GetByIdAsync(
                codigoMeioAmbienteCptm);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateEfluenteRequest request)
    {
        var result =
            await _service.CreateAsync(
                request);

        return CreatedAtAction(
            nameof(GetById),
            new
            {
                codigoMeioAmbienteCptm =
                    result.CodigoMeioAmbienteCptm
            },
            result);
    }

    [HttpPut("{codigoMeioAmbienteCptm}")]
    public async Task<IActionResult> Update(
        string codigoMeioAmbienteCptm,
        [FromBody] UpdateEfluenteRequest request)
    {
        await _service.UpdateAsync(
            codigoMeioAmbienteCptm,
            request);

        return NoContent();
    }

    [HttpDelete("{codigoMeioAmbienteCptm}")]
    public async Task<IActionResult> Delete(
        string codigoMeioAmbienteCptm)
    {
        await _service.DeleteAsync(
            codigoMeioAmbienteCptm);

        return NoContent();
    }
}