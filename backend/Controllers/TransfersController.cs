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
        readonly AppDatabase database;

        public TransfersController(AppDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<Transfer> Get()
        {
            return database.TransfersList;
        }


        [HttpGet("{sender}")]
        public IEnumerable<Transfer> Get(string sender)
        {
            return database.TransfersList.Where(transfer => transfer.Sender == sender);
        }

        [HttpPost]
        public Transfer Post([FromBody] Transfer transfer)
        {
            var newTransfer = database.TransfersList.Add(transfer).Entity;
            database.SaveChanges();
            return newTransfer;
        }
    }
}