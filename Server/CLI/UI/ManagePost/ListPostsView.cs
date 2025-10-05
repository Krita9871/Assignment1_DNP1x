using RepositoryContracts;

namespace CLI.UI.ManagePost;

public class ListPostsView
{
    private readonly IPostRepository postRepository;
    
    public ListPostsView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }


    public async Task ListPostsAsync()
    {
        Console.WriteLine($">>> Listing all posts");

        var posts = postRepository.GetManyAsync();

        if (!posts.Any())
        {
            Console.WriteLine("No posts found :(");
            return;
        }

        foreach (var post in posts)
        {
            Console.WriteLine($"{post.Id} - {post.Title}, {post.Id}, {post.UserId}");
        }

    }
    
}