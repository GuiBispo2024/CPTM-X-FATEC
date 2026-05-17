public interface IAuthService
{
    Task<LoginResponse> Login(LoginRequest request);
    Task ForgotPassword(ForgotPasswordRequest request);
    Task ResetPassword(ResetPasswordRequest request);
}