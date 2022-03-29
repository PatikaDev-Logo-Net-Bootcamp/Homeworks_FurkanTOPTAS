using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
