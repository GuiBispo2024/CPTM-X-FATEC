public class PasswordResetToken
{
    public int Id { get; private set; }

    public int UserId { get; private set; }

    public string Token { get; private set; } = null!;

    public DateTime ExpiresAt { get; private set; }

    public bool Used { get; private set; }

    protected PasswordResetToken() { }

    public PasswordResetToken(
        int userId,
        string token,
        DateTime expiresAt)
    {
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        Used = false;
    }

    public bool IsValid()
    {
        return !Used &&
               ExpiresAt > DateTime.UtcNow;
    }

    public void MarkAsUsed()
    {
        Used = true;
    }
}