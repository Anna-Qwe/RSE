using RSE.Core.Helpers;
using RSE.Core.Interfaces;
using RSE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE.Core
{
    public class Repository : IRepository
    {
        Context context = new Context();

        public IEnumerable<Exercise> Exercises { get { return context.Exercises;  } }
        public IEnumerable<Variant> Variants { get { return context.Variants; } }
       

        private User _authorizedUser;

        public object PasswordHelpers { get; private set; }

        public User GetAuthorizedUser()
        {
            return _authorizedUser;
        }

        public bool Authorize(string login, string password)
        {
            string hashedPassword = PasswordHelper.GetHash(password);
            User user = this.context.Users.SingleOrDefault(x => x.Login == login && x.Password == hashedPassword);
            if (user != null)
            {
                _authorizedUser = user;
                return true;
            }

            return false;
        }

        public void RegisterUser(User user)
        {
            User found = this.context.Users.SingleOrDefault(x => x.Login == user.Login);
            if (found != null)
                throw new InvalidOperationException("Dublicate username");

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }
    }
}

