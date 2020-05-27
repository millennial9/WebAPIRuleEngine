using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRuleEngine.Model;

namespace WebAPIRuleEngine.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly List<Ticket> ticketList = new List<Ticket>() {
            new Ticket(10,"ticket 1",State.Created),
            new Ticket(11,"ticket 2",State.Open),
            new Ticket(12,"ticket 3",State.Resolved),
            new Ticket(13,"ticket 4",State.Closed),
            new Ticket(14,"ticket 5",State.Blocked),
        };

        public List<Ticket> GetList()
        {
            return this.ticketList
                .ToList();
        }

        public Ticket GetById(int id)
        {
            return this.ticketList.Find(a => a.id == id);
        }

        public bool TicketExists(int id)
        {
            return this.ticketList.Any(a => a.id == id);
        }

        public Ticket Insert(Ticket ticket)
        {
            this.ticketList.Add(ticket);
            return ticket;
        }

        public Ticket Update(Ticket ticket)
        {
            Ticket t = this.ticketList.Find(ti => ti.id== ticket.id);
            t.state = ticket.state;
            t.desc = ticket.desc;
            return t;
        }

    }
}
