using System;
using RepositoryContracts;

namespace CLI.ManageUsers;

public class UpdateUserView
{

    private readonly IUserRepository userRepository;

    public UpdateUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task UpdateUserAsync()
    {
        Console.WriteLine(">>> Update the user:");

        Console.WriteLine("Enter user ID: ");

        var existingUsers = await userRepository.GetManyAsync();



        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("Invalid used ID.");
            return;
        }


        if (!existingUsers.Any(i => i.Id == userId))
        {
            Console.WriteLine("User with this ID is not found.");
            return;

        }

        Console.WriteLine("Enter a new Username >>>");
        string? username = Console.ReadLine();

        Console.WriteLine("Enter a new Password >>>");
        string? password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Either Username or Password is empty");
            return;
        }

        if (existingUsers.Any(u => username == u.UserName))
        {
            Console.WriteLine("The written username already exists");
        }

        var existingUser = await userRepository.GetSingleAsync(userId);



        var newUser = new User
        {
            Id = existingUser.Id,
            UserName = username,
            Password = password
        };

        await userRepository.UpdateAsync(newUser);

     }

}
