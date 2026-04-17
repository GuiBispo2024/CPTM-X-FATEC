public interface IUserService
{
    Task<List<UserResponse>> GetAll();
    Task<UserResponse> GetById(int id);
    Task<UserResponse> Create(UserRequest request);
    Task Update(int id, UserRequest request);
    Task Delete(int id);
}