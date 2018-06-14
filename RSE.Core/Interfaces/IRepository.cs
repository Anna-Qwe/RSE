using RSE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE.Core.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Exercise> Exercises { get; }
        IEnumerable<Variant> Variants { get; }
        IEnumerable<Teacher> Teachers { get; }

        List<int> WrongAnswers(int answer, int numbOfTask, Variant variant);
        bool Authorize(string login, string password);
        bool RegisterUser(User user, ref string errMessage);
        void SaveUserInfo(string email, string name);
        User GetAuthorizedUser();
    }
}
