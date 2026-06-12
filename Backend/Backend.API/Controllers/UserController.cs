using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    // =========================
    // ADMIN
    // =========================

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _service.GetById(id));

    [HttpPatch("{id}/admin")]
    public async Task<IActionResult> SetAdmin(
        int id,
        SetAdminRequest request)
    {
        var loggedUserId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        await _service.SetAdmin(
            id,
            request.IsAdmin,
            loggedUserId
        );

        return Ok(new
        {
            message = "Permissão alterada com sucesso"
        });
    }

    // delete administrativo
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var loggedUserId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        await _service.Delete(
            id,
            loggedUserId
        );

        return NoContent();
    }

    // =========================
    // PRÓPRIO USUÁRIO
    // =========================

    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var loggedUserId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        return Ok(
            await _service.GetById(loggedUserId)
        );
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create(
        UserRequest request)
    {
        var user = await _service.Create(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = user.Id },
            user
        );
    }

    [HttpPut("me")]
    public async Task<IActionResult> Update(
        UserUpdateRequest request)
    {
        var loggedUserId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        await _service.Update(
            loggedUserId,
            loggedUserId,
            request
        );

        return Ok(new
        {
            message = "Usuário atualizado com sucesso"
        });
    }

    [HttpPut("me/password")]
    public async Task<IActionResult> UpdatePassword(
        UpdatePasswordRequest request)
    {
        var loggedUserId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        await _service.UpdatePassword(
            loggedUserId,
            loggedUserId,
            request
        );

        return Ok(new
        {
            message = "Senha atualizada com sucesso"
        });
    }

    // delete da própria conta
    [HttpDelete("me")]
    public async Task<IActionResult> DeleteMyAccount()
    {
        var loggedUserId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        await _service.Delete(
            loggedUserId,
            loggedUserId
        );

        return NoContent();
    }
}