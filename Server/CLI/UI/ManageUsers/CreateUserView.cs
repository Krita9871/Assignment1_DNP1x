using System;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class CreateUserView
{

    private readonly IUserRepository userRepository;

    public CreateUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync()
    {
        
        Console.WriteLine(">>>Create a new user: ");
        
        Console.WriteLine("Write a username:");
        var username = Console.ReadLine();

        Console.WriteLine("Write a password");
        var password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Either username or password is empty");

        }
        var existingUsers = userRepository.GetManyAsync();
        
        if (existingUsers.Any(u => u.UserName == username))
        {
            Console.WriteLine("The written username already exists");
        }

        User user = new ()
        {
            UserName = username,
            Password = password
        };

        var createdUser = await userRepository.AddAsync(user);
        Console.WriteLine($"You've created a new user {user.UserName} with id {createdUser.Id}");
        return await Task.FromResult(createdUser); 
        
    }
        
}


