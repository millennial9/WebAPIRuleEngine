using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIRuleEngine.Exceptions;
using WebAPIRuleEngine.Model;
using WebAPIRuleEngine.Services;

namespace WebAPIRuleEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService ticketServices;

        public TicketController(TicketService injectedUsersServices)
        {
            this.ticketServices = injectedUsersServices;
        }

        [HttpGet]
        public List<Ticket> GetList()
        {
            return ticketServices.GetList();
        }

        [HttpPost]
        public List<Ticket> CreateTicket([FromBody]Ticket ticket)
        {
            this.ticketServices.Create(ticket);
            return GetList();
        }

        [HttpPut]
        public ActionResult<List<Ticket>> UpdateTicket([FromBody]Ticket ticket)
        {
            try
            {
                this.ticketServices.Update(ticket);
            }
            catch(ValidationException e)
            {
                string message="";
                foreach(var exception in e.BusinessValidationErrors)
                {
                    message += exception.Error;
                }
                return BadRequest(message);
            }
            return GetList();
        }
    }
}