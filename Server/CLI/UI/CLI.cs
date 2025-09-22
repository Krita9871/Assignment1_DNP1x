using System.Reflection.Metadata.Ecma335;
using CLI.UI.ManageComments;
using CLI.UI.ManagePost;
using CLI.UI.ManageUsers;
using RepositoryContracts;

namespace CLI.UI;

public class CLI
{
    private readonly ICommentRepository  commentRepository;
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    public async Task Run()
    {
        ManageCommentView manageCommentView = new ManageCommentView(commentRepository);
        ManageUserView manageUserView = new ManageUserView(userRepository);
        ManagePostsView managePostsView = new ManagePostsView(postRepository);
        
        Console.WriteLine("Welcome to the CLI!");
        Console.WriteLine("1. User Management");
        Console.WriteLine("2. Comment Management");
        Console.WriteLine("3. Post Management");
        Console.WriteLine("Any number to end the program");

        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Invalid number");
            Run();
        }

        while (true)
        {
            switch (number)
            {
                case 1:
                    await manageUserView.UserMenuAsync();
                    break;
                case 2:
                    await manageCommentView.ManageCommentsAsync();
                    break;
                case 3:
                    await managePostsView.ManagePostAsync();
                    break;
                default:
                    return;
            }
        }
    }
}