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
    [Route("api/Transfers")]
    public class TransfersController : Controller
    {

        static List<Transfer> transfersList = new List<Transfer>
        {
            new Transfer
            {
                Sender = "John",

                Amount = 30
            },
            new Transfer
            {
                Sender = "Tim",
                Amount = 20
            }
        };

        public IEnumerable<Transfer> Get()
        {
            return transfersList;
        }

        [HttpPost]
        public Transfer Post([FromBody] Transfer transfer)
        {
            transfersList.Add(transfer);
            return transfer;
        }
    }
}