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
    public class UpdatePageController : ApiController
    {
        // GET: UpdatePage
        UserModelLibrary value = new UserModelLibrary();


        static List<UserModelLibrary> getAllUsers = new List<UserModelLibrary>();

        UserBal bl = new UserBal();


        public IEnumerable<UserModelLibrary> Get(int userId)
        {
            return bl.GetUserDataforUpdatePage(userId);
        }
    }
}