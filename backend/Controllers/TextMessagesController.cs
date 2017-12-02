using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class TextMessagesController : Controller
    {

        static List<Message> messagesList = new List<Message>
        {
            new Message
            {
                Sender = "John",
                Text = "hello"
            },
            new Message
            {
                Sender = "Tim",
                Text = "diii"
            }
        };

        public IEnumerable<Message> Get()
        {
            return messagesList;
        }

        [HttpPost]
        public void Post([FromBody] Message message)
        {
            messagesList.Add(message);
        }
    }
}