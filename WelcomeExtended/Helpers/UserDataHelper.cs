using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    static class UserDataHelper
    {
        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (name == null)
            {
                throw new ArgumentException("The name cannot be empty");
            }

            if (password == null)
            {
                throw new ArgumentException("The password cannot be empty");
            }

            return userData.ValidateUserLambda(name, password);
        }

        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
