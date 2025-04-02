using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using Welcome.Others;
using System;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Kris", "12356d", UserRolesEnum.STUDENT);
            UserViewModel UVM1 = new UserViewModel(user1);
            UserView UV1 = new UserView(UVM1);

            UV1.Display();

            Console.ReadKey();



        }
    }
}

