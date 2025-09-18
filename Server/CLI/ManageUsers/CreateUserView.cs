using System;
using RepositoryContracts;

namespace CLI.ManageUsers;

public class CreateUserView
{

    private readonly IUserRepository userRepository;

    public CreateUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task CreateUserAsync()
    {
        Console.WriteLine(">>>Create a new user: ");

        try
        {
            Console.WriteLine("Write a username:");
            string? username = Console.ReadLine();

            Console.WriteLine("Write a password");
            string? password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Either username or password is empty");
                return;

            }

            var existingUsers = await userRepository.GetManyAsync();
            if (existingUsers.Any(u => u.UserName == username))
            {
                Console.WriteLine("The written username already exists");
                return;
            }

            var user = new User
            {
                UserName = username,
                Password = password
            };

            var createdUser = userRepository.Addsync(user);
            Console.WriteLine($"You've created a new user {user.UserName} with id {createdUser.Id}");



        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating user: {ex.Message}");
         }
     }

}
