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
            Email = u.Email
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
            Email = user.Email
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

    public async Task Update(int id, UserRequest request)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("Usuário não encontrado");

        user.Update(request.Name, request.Email);

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            var hash = _passwordHasher.Hash(request.Password);
            user.SetPasswordHash(hash);
        }

        await _repo.Update(user);
    }

    public async Task Delete(int id)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("Usuário não encontrado");

        await _repo.Delete(user);
    }
}