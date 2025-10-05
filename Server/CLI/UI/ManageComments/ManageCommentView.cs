using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class ManageCommentView
{
    private readonly CreateCommentsView createCommentsView;
    private readonly ListCommentsView listCommentsView;
    
    public ManageCommentView(ICommentRepository commentRepository)
    {
        createCommentsView = new CreateCommentsView(commentRepository);
        listCommentsView = new ListCommentsView(commentRepository);
    }

    public async Task ManageCommentsAsync()
    {
        while (true)
        {
            
            Console.WriteLine(">>> Manage Comments");
            Console.WriteLine("1. Create a new comment");
            Console.WriteLine("2. List all comments");
            Console.WriteLine("Any number to return to main menu");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid number");
                return;
            }

            
            
            switch (number)
            {
                case 1:
                    await createCommentsView.CreateCommentAsync();
                    break;
                case 2:
                    await listCommentsView.ListCommentsAsync();
                    break;
                default:
                    return;
            }
        }
        
    }
}