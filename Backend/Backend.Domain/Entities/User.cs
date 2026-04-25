public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public bool IsAdmin { get; private set; }

    protected User() { } // EF Core

    public User(string name, string email, string passwordHash)
    {
        Validate(name, email, passwordHash);

        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        IsAdmin = false;
    }
    public void SetAdmin(bool isAdmin)
    {
        IsAdmin = isAdmin;
    }
    public void MakeAdmin()
    {
        IsAdmin = true;
    }
    public void Update(string name, string email)
    {
        Validate(name, email, PasswordHash);

        Name = name;
        Email = email;
    }
    public void UpdatePassword(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
            throw new Exception("Senha inválida");

        PasswordHash = newPasswordHash;
    }
    private void Validate(string name, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Nome obrigatório");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new Exception("Email inválido");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new Exception("Senha inválida");
    }
}