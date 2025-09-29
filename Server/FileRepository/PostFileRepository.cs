using System.Text.Json;
using RepositoryContracts;

namespace FileRepository;

public class PostFileRepository : IPostRepository
{
    private readonly string filePath = "posts.json";


    public PostFileRepository()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }
    
    
    public async Task<Post> AddAsync(Post post)
    {
        string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        posts.Add(post);
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(posts));
        return post;
        
    }

    public async Task UpdateAsync(Post post)
    {
        string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        posts.Add(post);
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(posts));
    }

    public async Task DeleteAsync(int id)
    {
        string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        posts.Remove(posts.First(p => p.Id == id));
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(posts));
    }

    public async Task<Post> GetSingleAsync(int id)
    {
        string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        return posts.SingleOrDefault(p => p.Id == id);
        
    }

    public Task<IQueryable<Post>> GetManyAsync()
    {
        string postsAsJson = File.ReadAllText(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        return Task.FromResult(posts.AsQueryable());
    }
}