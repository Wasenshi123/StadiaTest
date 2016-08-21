using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebService.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        public string Msg(string msg)
        {
            ServiceEventSource.Current.Message("A client has sent a message: " + msg);
            return "You have said : '" + msg + "' to the server!";
        }
        [HttpPost]
        public string PostMsg([FromBody]string msg)
        {
            ServiceEventSource.Current.Message("request detail: \n" + Request);





            ServiceEventSource.Current.Message("A client has sent a message: " + msg);
            return "You have said : '" + msg + "' to the server!";
        }
    }
}
