using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // Create a user
            var user = new DatabaseUser
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };
            var studentUser = new DatabaseUser
            {
                Id = 2,
                Name = "student",
                Password = "student123",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddDays(180)
            };

            var professorUser = new DatabaseUser
            {
                Id = 3,
                Name = "professor",
                Password = "prof123",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddDays(365)
            };

            var inspectorUser = new DatabaseUser
            {
                Id = 4,
                Name = "inspector",
                Password = "inspect123",
                Role = UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddDays(90)
            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(user,studentUser,professorUser,inspectorUser);
        }
    }
}
