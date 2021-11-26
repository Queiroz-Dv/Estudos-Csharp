using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStudy.Models.Users
{
    public class LoginViewModelOutput
    {
        public string Token { get; set; }
        public LoginViewModelDetailsOutput User { get; set; }
    }

    public class LoginViewModelDetailsOutput
    {
        
        public int Coding { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }
    }
}
