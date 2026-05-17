public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;

    private readonly IPasswordResetTokenRepository
        _tokenRepo;

    private readonly IPasswordHasher _hasher;

    private readonly ITokenService _tokenService;

    private readonly IEmailService _emailService;

    public AuthService(
        IUserRepository userRepo,
        IPasswordResetTokenRepository tokenRepo,
        IPasswordHasher hasher,
        ITokenService tokenService,
        IEmailService emailService)
    {
        _userRepo = userRepo;
        _tokenRepo = tokenRepo;
        _hasher = hasher;
        _tokenService = tokenService;
        _emailService = emailService;
    }

    public async Task<LoginResponse> Login(
        LoginRequest request)
    {
        var user =
            await _userRepo.GetByEmail(
                request.Email);

        if (user == null)
            throw new Exception(
                "Email ou senha inválidos");

        var valid =
            _hasher.Verify(
                user.PasswordHash,
                request.Password);

        if (!valid)
            throw new Exception(
                "Email ou senha inválidos");

        var token =
            _tokenService.GenerateToken(user);

        return new LoginResponse
        {
            Token = token
        };
    }

    public async Task ForgotPassword(
        ForgotPasswordRequest request)
    {
        var user =
            await _userRepo.GetByEmail(
                request.Email);

        if (user == null)
            return;

        var token =
            Guid.NewGuid().ToString();

        var resetToken =
            new PasswordResetToken(
                user.Id,
                token,
                DateTime.UtcNow.AddMinutes(15)
            );

        await _tokenRepo.Create(resetToken);

        await _emailService.Send(
            user.Email,
            "Recuperação de senha",
            $"Clique no link:\n{token}"
        );
    }

    public async Task ResetPassword(
        ResetPasswordRequest request)
    {
        var tokenEntity =
            await _tokenRepo.GetByToken(
                request.Token);

        if (tokenEntity == null ||
            !tokenEntity.IsValid())
        {
            throw new Exception(
                "Token inválido");
        }

        var user =
            await _userRepo.GetById(
                tokenEntity.UserId);

        if (user == null)
            throw new Exception(
                "Usuário não encontrado");

        user.UpdatePassword(
            _hasher.Hash(
                request.NewPassword)
        );

        tokenEntity.MarkAsUsed();

        await _userRepo.Update(user);

        await _tokenRepo.Update(tokenEntity);
    }
}