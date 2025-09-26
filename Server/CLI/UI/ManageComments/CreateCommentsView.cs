using System.Reflection.Metadata.Ecma335;

using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class CreateCommentsView
{
    private readonly ICommentRepository commentRepository;

    public CreateCommentsView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }
    public async Task<Comment> CreateCommentAsync()
    {
        
        Console.WriteLine($">>> Creating a post");
        Console.WriteLine($"> Body: ");
        var body = Console.ReadLine();
        Console.WriteLine($"> Post id: ");
        var postId = int.Parse(Console.ReadLine());
        Console.WriteLine($"> User id: ");
        var userId = int.Parse(Console.ReadLine());
        var comment = new Comment()
        {
            Body = body,
            PostId = postId,
            UserId = userId
        };
        Comment created = await commentRepository.AddAsync(comment);
        Console.WriteLine($"You've created a new comment: Body of a comment {created.Body}, User id {created.UserId}, Post id {created.PostId}");
        return await Task.FromResult(created);
    }
    
}