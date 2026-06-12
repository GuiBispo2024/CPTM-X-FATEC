public interface IUserService
{
    Task<List<UserResponse>> GetAll();
    Task<UserResponse> GetById(int id);
    Task<UserResponse> Create(UserRequest request);
    Task Update(int id, int loggedUserId, UserUpdateRequest request);
    Task UpdatePassword(int id, int loggedUserId, UpdatePasswordRequest request);
    Task SetAdmin(int targetUserId, bool isAdmin, int requesterId);
    Task Delete(int id, int loggedUserId);
}