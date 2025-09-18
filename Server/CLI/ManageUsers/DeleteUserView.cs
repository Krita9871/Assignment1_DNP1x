using System;
using RepositoryContracts;

namespace CLI.ManageUsers;

public class DeleteUserView
{

    private readonly IUserRepository userRepository;

    public DeleteUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task DeleteUserAsync()
    {
        try
        {
            Console.WriteLine(">>> Delete the user: ");

            Console.WriteLine("Enter ID: ");

            if (!int.TryParse(Console.ReadLine(), out int usedId))
            {
                Console.WriteLine("Invalid user ID");
                return;
            }

            await userRepository.DeleteAsync(usedId);

        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
         }
     }

}
