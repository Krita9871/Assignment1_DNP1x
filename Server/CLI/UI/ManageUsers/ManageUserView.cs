using System;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUserView
{

    private readonly CreateUserView createUserView;
    private readonly ListUserView listUserView;
    private readonly DeleteUserView deleteUserView;

    public ManageUserView(IUserRepository userRepository)
    {
        createUserView = new CreateUserView(userRepository);
        listUserView = new ListUserView(userRepository);
        deleteUserView = new DeleteUserView(userRepository);
    }



    public async Task UserMenuAsync()
    {
        while (true)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" User Management. Select number... ");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. List all Users");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Leave User Management");


            var number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    await createUserView.CreateUserAsync();
                    break;
                case "2":
                    await listUserView.ListUserAsync();
                    break;
                case "3":
                    await deleteUserView.DeleteUserAsync();
                    break;
                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
             }
        
         }

     }

}
