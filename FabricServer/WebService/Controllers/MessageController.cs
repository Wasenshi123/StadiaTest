using System.Collections.Generic;
using System.Web.Http;

namespace WebService.Controllers
{
    class MessageController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        public string RecieveMsg(string msg)
        {
            ServiceEventSource.Current.Message("A client has sent a message: " + msg);
            return "You have said : '" + msg + "' to the server!";
        }
    }
}
