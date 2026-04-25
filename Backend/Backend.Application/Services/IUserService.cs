public interface IUserService
{
    Task<List<UserResponse>> GetAll();
    Task<UserResponse> GetById(int id);
    Task<UserResponse> Create(UserRequest request);
    Task Update(int id, UserUpdateRequest request);
    Task UpdatePassword(int id, UpdatePasswordRequest request);
    Task SetAdmin(int targetUserId, bool isAdmin, int requesterId);
    Task Delete(int id);
}