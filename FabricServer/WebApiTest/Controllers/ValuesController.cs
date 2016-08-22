using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            

            return "value";
        }

        // POST api/values 
        [HttpPost]
        public string Post([FromBody]MyModel value)
        {
            ServiceEventSource.Current.Message("receive firstname data:" + value.firstName);

            return value.firstName.ToUpper();
        }

        public class MyModel
        {

            public string firstName;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
