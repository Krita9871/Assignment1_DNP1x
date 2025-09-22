using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class ListCommentsView
{
    private readonly ICommentRepository commentRepository;
    
    public ListCommentsView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }

    public async Task ListCommentsAsync()
    {
        Console.WriteLine($">>> List of all comments");
        var comments = await commentRepository.GetManyAsync();
        
        
        if (!comments.Any())
        {
            Console.WriteLine(">>> No comments found ;(");
            return;
        }
        
        
        foreach (var comment in comments)
            {
            Console.WriteLine($">>> Comment #{comment.Id}");
            }
        

    }
}