using RSE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE.Core.Interfaces
{
    interface IRepository
    {
        IEnumerable<Exercise> Exercises { get; }
        IEnumerable<Variant> Variants { get; }
       

        bool Authorize(string login, string password);
        void RegisterUser(User user);
        User GetAuthorizedUser();
    }
}
