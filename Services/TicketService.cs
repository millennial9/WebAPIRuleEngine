using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRuleEngine.Model;
using WebAPIRuleEngine.Repositories;

namespace WebAPIRuleEngine.Services
{
    public class TicketService : RuleService
    {
        private ITicketRepository TicketsRepository { get; }

        public TicketService(ITicketRepository ticketsRepository)
        {
            this.TicketsRepository = ticketsRepository;
        }

        public bool TicketExists(int id)
        {
            return this.TicketsRepository.TicketExists(id);
        }

        public Ticket GetById(int id)
        {
            return this.TicketsRepository.GetById(id);
        }

        public List<Ticket> GetList()
        {
            return this.TicketsRepository.GetList();
        }

        public Ticket Create(Ticket ticket)
        {
            //Insert facts into rules engine's memory
            this.RulesSession.Insert(ticket);
            this.RunRulesSession(true);
            return this.TicketsRepository.Insert(ticket);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Ticket Update(Ticket newTicket)
        {
            Ticket oldTicket = GetById(newTicket.id);
            oldTicket.desc = newTicket.desc;
            oldTicket.solution = newTicket.solution;
            oldTicket.state = newTicket.state;
            oldTicket.usage = newTicket.usage;

            //Insert facts into rules engine's memory
            RulesSession.Insert(oldTicket);
            RunRulesSession(true);

            return this.TicketsRepository.Update(newTicket);
        }

        public void ModifyTicket(string action, string prop, object newValue)
        {
            throw new NotImplementedException();
        }
    }
}