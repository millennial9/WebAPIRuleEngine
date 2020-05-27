using System;
using System.Collections.Generic;
using WebAPIRuleEngine.Model;

namespace WebAPIRuleEngine.Repositories
{
    public interface ITicketRepository
    {
        bool TicketExists(int id);
        List<Ticket> GetList();
        Ticket GetById(int id);
        Ticket Insert(Ticket ticket);
        Ticket Update(Ticket ticket);
    }
}
