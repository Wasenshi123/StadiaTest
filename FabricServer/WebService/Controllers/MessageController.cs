using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebService.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        public string Msg(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                ServiceEventSource.Current.Message("A client has sent a corrupted message.");
                return "You are doing something wrong! specify a proper message!";
            }
            ServiceEventSource.Current.Message("A client has sent a message: " + msg);
            return "You have said : '" + msg + "' to the server!";
        }
        [HttpPost]
        public string PostMsg([FromBody]PostData data)
        {
            if (data == null || string.IsNullOrEmpty(data.msg))
            {
                ServiceEventSource.Current.Message("A client has sent a corrupted message.");
                return "You are doing something wrong! specify a proper message!";
            }
            ServiceEventSource.Current.Message("A client has sent a message: " + data.msg);
            return "You have said : '" + data.msg + "' to the server!";
        }

        public class PostData
        {
            public string msg;
        }
    }
}
