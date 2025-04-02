using DataLayer.Database;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Welcome.Others;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = UserRolesEnum.STUDENT
                });
                context.SaveChanges();
                var users = context.Users.ToList();
                Console.WriteLine("All users in database:");
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Role: {user.Role}, Expires: {user.Expires:yyyy-MM-dd}");
                }

                // Check for valid username and password
                Console.WriteLine("\nEnter username:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                var foundUser = users.FirstOrDefault(u => u.Name == username && u.Password == password);

                if (foundUser != null)
                {
                    Console.WriteLine("Valid user");
                    Console.WriteLine($"User details - ID: {foundUser.Id}, Name: {foundUser.Name}, Role: {foundUser.Role}");
                }
                else
                {
                    Console.WriteLine("Invalid credentials");
                }
                Console.ReadKey();
            }
        }
    }
}
