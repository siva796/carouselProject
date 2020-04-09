using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UserModel;
using UserDalLibrary;
using UserBalLibrary;
namespace CarouselWebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT")]
    public class ValuesController : ApiController
    {
        // GET api/values
        UserModelLibrary value = new UserModelLibrary();


        static List<UserModelLibrary> getAllUsers = new List<UserModelLibrary>();

        UserBal bl = new UserBal();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5/5
        public IEnumerable<UserModelLibrary> Get()
        {
            return bl.GetUserData();
        }


        // POST api/values
        public bool Post([FromBody]UserModelLibrary value)
        { 
            return bl.InsertSavePage(value);
        }

        // PUT api/values/5
        public bool Put(int userId, [FromBody]UserModelLibrary value)
        {
            return bl.UpdateUser(userId,value);
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
