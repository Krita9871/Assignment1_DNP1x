using System;
using RepositoryContracts;

namespace CLI.ManageUsers;

public class ListUserView
{
    private readonly IUserRepository userRepository;

    public ListUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task ListUserAsync()
    {

        Console.WriteLine(">>> All current user");

        try
        {

            var users = userRepository.GetManyAsync();
            if (!users.Any())
            {
                Console.WriteLine("There is no users :(");
                return;

            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}, {user.UserName}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
         }
     }

}
