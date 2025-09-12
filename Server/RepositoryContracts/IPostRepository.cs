namespace RepositoryContracts;

public interface IPostRepository
{

    Task<Post> AddSync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task<Post> GetSingleAsync(int id);
    IQueryable<Post> GetManyAsync();

}
