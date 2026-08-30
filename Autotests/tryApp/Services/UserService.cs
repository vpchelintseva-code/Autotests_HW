using Autotests.TryApp.Interfaces;

namespace Autotests.TryApp.Services;

public sealed class UserService(IUserApi api) : IUserService
{
    public Task<User> GetUserAsync(int id) => api.GetUserAsync(id);

    public bool IsUserValid(int id) => id > 0;
}
