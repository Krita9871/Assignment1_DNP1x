using System;
using RepositoryContracts;

namespace CLI.ManageUsers;

public class ManageUserView
{

    private readonly CreateUserView createUserView;
    private readonly UpdateUserView updateUserView;
    private readonly ListUserView listUserView;
    private readonly DeleteUserView deleteUserView;

    private readonly IUserRepository userRepository;

    public ManageUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        createUserView = new CreateUserView(userRepository);
        updateUserView = new UpdateUserView(userRepository);
        listUserView = new ListUserView(userRepository);
        deleteUserView = new DeleteUserView(userRepository);
    }



    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" User Managment. Select number... ");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. List all Users");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Leave User Managment");


            var number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    await createUserView.CreateUserAsync();
                    break;
                case "2":
                    await updateUserView.UpdateUserAsync();
                    break;
                case "3":
                    await listUserView.ListUserAsync();
                    break;
                case "4":
                    await deleteUserView.DeleteUserAsync();
                    break;
                case "5":
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
             }
        
         }

     }

}
