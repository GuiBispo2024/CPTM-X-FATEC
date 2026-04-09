using Backend.Models;

public class UserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public List<Users> GetUsers()
    {
        return _repository.GetAll();
    }

    public Users CreateUser(Users user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
            throw new ArgumentException("Nome é obrigatório");

        if (string.IsNullOrWhiteSpace(user.Email))
            throw new ArgumentException("Email é obrigatório");

        if (string.IsNullOrWhiteSpace(user.Password))
            throw new ArgumentException("Senha é obrigatória");

        _repository.Add(user);

        return user;
    }

    public bool UpdateUser(int id, Users user)
    {
        return _repository.Update(id, user);
    }

    public bool DeleteUser(int id)
    {
        return _repository.Delete(id);
    }
}