using Backend.Models;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Users> GetAll()
    {
        return _context.Users.ToList();
    }

    public Users GetById(int id)
    {
        return _context.Users.Find(id);
    }

    public void Add(Users user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public bool Update(int id, Users user)
    {
        var existing = _context.Users.Find(id);

        if (existing == null)
            return false;

        existing.Name = user.Name;
        existing.Email = user.Email;
        existing.Password = user.Password;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
            return false;

        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }
}