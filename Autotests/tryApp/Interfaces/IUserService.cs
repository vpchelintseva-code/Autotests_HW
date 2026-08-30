using Refit;

namespace Autotests.TryApp.Interfaces;

public record User(int Id, string Name);

public interface IUserApi
{
    [Get("users/{id}")]
    Task<User> GetUserAsync(int id);
}

public interface IUserService
{
    Task<User> GetUserAsync(int id);
    bool IsUserValid(int id);
}
