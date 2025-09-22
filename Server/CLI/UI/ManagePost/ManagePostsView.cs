using CLI.UI.ManageComments;
using RepositoryContracts;

namespace CLI.UI.ManagePost;

public class ManagePostsView
{   
    private readonly CreatePostView createPostView;
    private readonly ListPostsView listPostsView;
    
    
    public ManagePostsView(IPostRepository postRepository)
    {
        createPostView = new CreatePostView(postRepository);
        listPostsView = new ListPostsView(postRepository);
        
    }

    public async Task ManagePostAsync()
    {
        Console.WriteLine($">>> Manage posts");
        Console.WriteLine("1. Create a post");
        Console.WriteLine("2. List a posts");
        Console.WriteLine("Any number to Return to CLI menu");
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine($"Invalid number");
        }

        while (true)
        {
            switch (number)
            {
                case 1: 
                    await createPostView.CreatePostAsync();
                    break;
                
                case 2: 
                    await listPostsView.ListPostsAsync();
                    break;
                
                default:
                    return ;
            }
        }
    }

}  