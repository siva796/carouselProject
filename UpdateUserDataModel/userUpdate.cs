using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateUserDataModel
{
    public class userUpdate
    {
        private string email;
        private string userName;

        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
    }
}
