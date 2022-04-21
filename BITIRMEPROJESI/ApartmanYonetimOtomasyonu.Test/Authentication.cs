using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Test
{
    public class Authentication
    {
        public bool Login(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 15 || username.Length < 0)
                throw new InvalidOperationException();
            return true;
        }
        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 15)
                throw new InvalidOperationException();
            if (string.IsNullOrEmpty(password) || username.Length > 15)
                throw new InvalidOperationException();
            return true;
        }
    }
}
