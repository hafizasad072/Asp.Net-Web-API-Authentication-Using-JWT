using System.Web.Http;
using WebApi.Jwt.Filters;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http.Cors;
using HelperModel;

namespace WebApi.Jwt.Controllers
{
    [RoutePrefix("api/NXBBook")]
    [EnableCors(origins: "http://localhost:58823/", headers: "*", methods: "get")]
    
    public class BookController : ApiController
    {

        [HttpGet]
        [JwtAuthentication]
        [Route("GetAllBooks")]
        public IEnumerable<HMBook> AllBooks()
        {
            try
            {
                using (DB.NXBEntities _context = new DB.NXBEntities())
                {
                    return _context.tbl_Book.Select(x => new HMBook { Author = x.Author, BookName = x.BookName, Category = x.Category }).ToList();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
