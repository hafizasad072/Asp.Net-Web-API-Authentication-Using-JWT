using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HelperModel
{
    public class HMClient
    {
        public static HttpClient GetHttpClient()
        {
            var MyHttpClient = new HttpClient();
            dynamic _token = HttpContext.Current.Session["token"];
            if (_token == null) throw new ArgumentNullException(nameof(_token));
            MyHttpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _token));
            return MyHttpClient;
        }
    }
}
