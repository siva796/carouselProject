using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModel
{
    public class UserModelLibrary
    {
        public string userName { get; set; }
        public string email { get; set; }
        public int userId { get; set; }
        public int isDeleted { get; set; }
        public int status { get; set; }
        public int skipRows { get; set; }
        public int topRows { get; set; }
    }
}
