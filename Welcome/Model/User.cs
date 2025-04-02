using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string _name;
        private string _password;
        private UserRolesEnum _role;
        private int _id;
        private DateTime _expires;
        public User() { }

        public User(string name, string password, UserRolesEnum role)
        {
            _name = name;
            _password = password;
            _role = role;
        }

        public User(string name, string password, UserRolesEnum role, int id, DateTime expires)
        {
            _name = name;
            _password = password;
            _role = role;
            _id = id;
            _expires = expires;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
    }
}

