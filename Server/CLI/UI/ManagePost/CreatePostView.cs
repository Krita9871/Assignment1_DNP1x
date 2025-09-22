using System;
using RepositoryContracts;

namespace CLI.UI.ManagePost;

public class CreatePostView
{
    private readonly IPostRepository postRepository;

    public CreatePostView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }
    public async Task<Post> CreatePostAsync()
    {
        
        Console.WriteLine($">>> Creating a post");
        
        Console.WriteLine($"> Title: ");
        var title = Console.ReadLine();
        Console.WriteLine($"> Body: ");
        var body = Console.ReadLine();
        Console.WriteLine($"> User id: ");
        if (!int.TryParse(Console.ReadLine(), out var userId))
        {
            Console.WriteLine($"Invalid user id");
        }
        
        Post post = new()
        {
            Title = title,
            Body = body,
            UserId = userId
        };

        var newpost = await postRepository.AddAsync(post);
        return await Task.FromResult(newpost);
     }

}
