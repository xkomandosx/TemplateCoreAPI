using templateAPI.Domain;

namespace templateAPI.Repositories;

public interface IUserRepository : ICrudRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    Task<User?> FindByEmailAsync(string email);
}