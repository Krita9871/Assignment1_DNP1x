
using System.Reflection.Metadata;
using RepositoryContracts;

namespace InMemoryRepository;

public class UserInMemoryRepository : IUserRepository
{
    private List<User> users = [];

    public Task UpdateAsync(User user)
    {
        User? existingPost = users.SingleOrDefault(p => p.Id == user.Id);
        if (existingPost is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{user.Id}' not found");
        }

        users.Remove(existingPost);
        users.Add(user);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        User? postToRemove = users.SingleOrDefault(p => p.Id == id);
        if (postToRemove is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{id}' not found");
        }
        users.Remove(postToRemove);
        return Task.CompletedTask;
    }

    public Task<User> GetSingleAsync(int id)
    {
        User? user = users.SingleOrDefault(p => p.Id == id);
        if (user is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{id}' not found");
        }
        return Task.FromResult(user);
    }

    public Task<IQueryable<User>> GetManyAsync()
    {
        return Task.FromResult(users.AsQueryable());
    }

    public Task<User> Addsync(User user)
    {
        user.Id = users.Any()
            ? users.Max(p => p.Id) + 1
            : 1;
        users.Add(user);
        return Task.FromResult(user);
    }
}
