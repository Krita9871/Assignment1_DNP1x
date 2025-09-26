using System;
using System.Threading.Tasks;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ListUserView
{
    private readonly IUserRepository userRepository;

    public ListUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task ListUserAsync()
    {

        IQueryable<User> userList = userRepository.GetManyAsync();
        List<User> list = userList.ToList();
        foreach (var user in list)
        {

            Console.WriteLine($"{user.UserName}, {user.Password}, {user.Id}");
        }
        
    }

}
