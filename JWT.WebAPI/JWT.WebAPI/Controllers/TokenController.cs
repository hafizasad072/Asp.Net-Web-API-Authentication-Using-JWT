using System.Net;
using System.Web.Http;
using System.Linq;
using System;
using HelperModel;
using System.Web.Http.Cors;

namespace WebApi.Jwt.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {

        [AllowAnonymous]
        [HttpPost]
        [Route("GetToken")]
        public string Post(HMLoginModel data)
        {
            if (CheckUser(data))
            {
                return JwtManager.GenerateToken(data.Username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
        [NonAction]
        public bool CheckUser(HMLoginModel data)
        {
            try
            {
                using (DB.NXBEntities _context = new DB.NXBEntities())
                {
                    var user = _context.tbl_User.Where(x => x.UserName == data.Username && x.Password == data.Password).FirstOrDefault();
                    if (user != null)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
