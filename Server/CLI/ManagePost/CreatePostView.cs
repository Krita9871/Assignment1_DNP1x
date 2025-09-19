using System;
using RepositoryContracts;

namespace CLI.ManagePost;

public class CreatePostView
{
    private readonly IPostRepository postRepository;

    public CreatePostView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }




    public async Task StartPostAsync(int userId)
    {
        try
        {


            Console.WriteLine(">>> Create a post: ");

            Console.WriteLine("Write title: ");
            string? title = Console.ReadLine();

            Console.WriteLine("Write title: ");
            string? body = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(body))
                {
                    Console.WriteLine("Title and body cannot be empty.");
                    return;
                }

await CreatePostAsync(title, body, userId);

            await CreatePostAsync(title, body, userId);
            await Task.CompletedTask;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
         }
    }

    public async Task<Post> CreatePostAsync(string title, string body, int userId)
    {
        Post post = new()
        {
            Title = title,
            Body = body,
            UserId = userId
        };

        var newpost = await postRepository.AddSync(post);
        return await Task.FromResult(newpost);
     }

}
