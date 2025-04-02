using System;
using System.Net.WebSockets;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;
using Welcome;
using System.Runtime.ConstrainedExecution;
using WelcomeExtended.Data;
using System.Data;
using System.Xml.Linq;
using WelcomeExtended.Helpers;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main()
        {
            //User user1 = new User("Kristian", "12356", UserRolesEnum.STUDENT);
            //UserViewModel UVM1 = new UserViewModel(user1);
            //UserView UV1 = new UserView(UVM1);

            //UV1.Display();

            //try
            //{
            //    var user = new User
            //    (
            //        "John",
            //         "password",
            //        UserRolesEnum.STUDENT
            //    );

            //    var viewModel = new UserViewModel(user);
            //    var view = new UserView(viewModel);

            //    view.Display();
            //    view.DisplayError();
            //}
            //catch (Exception e)
            //{
            //    var log = new ActionOnError(Delegates.Log);
            //    log(e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Executed in any case!");
            //}

            try
            {
                UserData userData = new UserData();
                User studentUser = new User("Student", "123", UserRolesEnum.STUDENT);
                userData.AddUser(studentUser);
                User studentUser1 = new User("Student2", "1234", UserRolesEnum.STUDENT);
                userData.AddUser(studentUser1);
                User teacherUser = new User("Teacher", "1234", UserRolesEnum.PROFESSOR);
                userData.AddUser(teacherUser);
                User adminUser = new User("Admin", "12345", UserRolesEnum.ADMIN);
                userData.AddUser(adminUser);
                Console.WriteLine("ENTER NAME: ");
                string name1 = Console.ReadLine();
                Console.WriteLine("ENTER PASSWORD: ");
                string password1 = Console.ReadLine();
                if (UserDataHelper.ValidateCredentials(userData, name1, password1))
                {
                    User user = UserDataHelper.GetUser(userData, name1, password1);
                    Console.WriteLine(UserHelper.ToUserString(user));
                }
                else throw new ArgumentException("User not found!");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }

        }
    }
}
