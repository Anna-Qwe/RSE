using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSE.Core.Models;

namespace RSE.Core.Helpers
{
    public class UserInfoHelper
    {
        public static bool CheckUser(User user)
        {
            return user.Login != String.Empty;
        }

        public static bool CheckUser(string email, string name)
        {
            return name != String.Empty && IsValidEmail(email);
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
