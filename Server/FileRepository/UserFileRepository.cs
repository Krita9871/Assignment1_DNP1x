using System.Text.Json;
using RepositoryContracts;

namespace FileRepository;

public class UserFileRepository : IUserRepository
{
    private readonly string filePath = "users.json";

    public UserFileRepository()
    {

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }

    public async Task<User> AddAsync(User user)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        int maxId = users.Count > 0 ? users.Max(u => u.Id) : 1;
        user.Id = maxId + 1;
        users.Add(user);
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(users));
        return user;
        
    }

    public async Task<User> GetSingleAsync(int id)
    {
        string userAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(userAsJson)!;
        var user = users.SingleOrDefault(u => u.Id == id);
        if (user == null)
        {
            Console.WriteLine("User not found");
        }
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        var userToUpdate = users.SingleOrDefault(u => u.Id == user.Id);
        users.Remove(userToUpdate);
        users.Add(user);
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(users));
    }
    public async Task DeleteAsync(int id)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        var userToDelete = users.SingleOrDefault(u => u.Id == id);
        users.Remove(userToDelete);
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(users));
    }

    public IQueryable<User> GetManyAsync()
    {
        string usersAsJson = File.ReadAllTextAsync(filePath).Result;
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        return users.AsQueryable();

    }
}