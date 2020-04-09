using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Cors;
using UserModel;
using UserDalLibrary;
using UserBalLibrary;

namespace CarouselWebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT")]
    public class SoftDeleteController : ApiController
    {
        // GET: SoftDelete

        UserModelLibrary value = new UserModelLibrary();


        static List<UserModelLibrary> getAllUsers = new List<UserModelLibrary>();

        UserBal bl = new UserBal();
        public bool Put(int userId, [FromBody]int isDeleted)
        {
            return bl.SoftDeleteUser(userId, isDeleted);
        }

    }
}