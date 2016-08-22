using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WebService.Controllers.Tests
{
    [TestClass()]
    public class MessageControllerTests
    {
        [TestMethod()]
        public void MsgTest()
        {
            
        }

        [TestMethod()]
        public void PostMsgTest()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:25331/api/message");

            var postData = "msg=hello hahaha!";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}