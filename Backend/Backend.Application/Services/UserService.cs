public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository repo, IPasswordHasher passwordHasher)
    {
        _repo = repo;
        _passwordHasher = passwordHasher;
    }

    public async Task<List<UserResponse>> GetAll()
    {
        var users = await _repo.GetAll();

        return users.Select(u => new UserResponse
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            IsAdmin = u.IsAdmin
        }).ToList();
    }

    public async Task<UserResponse> GetById(int id)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("Usuário não encontrado");

        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            IsAdmin = user.IsAdmin
        };
    }

    public async Task<UserResponse> Create(UserRequest request)
    {
        var tempUser = new User(request.Name, request.Email, "temp");

        var hash = _passwordHasher.Hash(request.Password);
        var user = new User(request.Name, request.Email, hash);

        await _repo.Add(user);

        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            IsAdmin = user.IsAdmin
        };
    }

    public async Task Update(int id, UserUpdateRequest request)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("Usuário não encontrado");

        // valida senha atual
        var valid = _passwordHasher.Verify(user.PasswordHash, request.CurrentPassword);

        if (!valid)
            throw new Exception("Senha inválida");

        user.Update(request.Name, request.Email);

        await _repo.Update(user);
    }

    public async Task UpdatePassword(int id, UpdatePasswordRequest request)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("Usuário não encontrado");

        var valid = _passwordHasher.Verify(user.PasswordHash, request.CurrentPassword);

        if (!valid)
            throw new Exception("Senha atual inválida");

        var newHash = _passwordHasher.Hash(request.NewPassword);

        user.UpdatePassword(newHash);

        await _repo.Update(user);
    }

    public async Task SetAdmin(int targetUserId, bool isAdmin, int requesterId)
    {
        var requester = await _repo.GetById(requesterId);

        if (requester == null)
            throw new Exception("Usuário solicitante não encontrado");

        if (!requester.IsAdmin)
            throw new UnauthorizedAccessException("Apenas admins podem alterar permissões");

        var target = await _repo.GetById(targetUserId);

        if (target == null)
            throw new Exception("Usuário alvo não encontrado");

        if (target.Id == requesterId)
            throw new Exception("Você não pode alterar seu próprio nível de acesso");

        target.SetAdmin(isAdmin); //sem requesterId

        await _repo.Update(target);
    }

    public async Task Delete(int id)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("Usuário não encontrado");

        await _repo.Delete(user);
    }
}