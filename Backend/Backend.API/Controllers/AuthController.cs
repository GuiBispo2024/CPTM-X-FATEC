using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(
        IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequest request)
    {
        return Ok(
            await _service.Login(request)
        );
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult>
        ForgotPassword(
            ForgotPasswordRequest request)
    {
        await _service.ForgotPassword(
            request);

        return Ok(new
        {
            message =
                "Se o email existir, um link foi enviado"
        });
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult>
        ResetPassword(
            ResetPasswordRequest request)
    {
        await _service.ResetPassword(
            request);

        return Ok(new
        {
            message =
                "Senha redefinida"
        });
    }
}