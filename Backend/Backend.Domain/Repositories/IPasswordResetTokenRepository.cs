public interface IPasswordResetTokenRepository
{
    Task Create(PasswordResetToken token);
    Task<PasswordResetToken?> GetByToken(string token);
    Task Update(PasswordResetToken token);
}