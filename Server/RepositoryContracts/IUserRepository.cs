namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User> Addsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int id);
    Task<IQueryable<User>> GetManyAsync();
}
