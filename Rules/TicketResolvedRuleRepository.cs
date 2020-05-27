using NRules.RuleModel;
using System.Collections.Generic;
using WebAPIRuleEngine.Codes;
using WebAPIRuleEngine.Model;
using WebAPIRuleEngine.Validations;

namespace WebAPIRuleEngine.Rules
{
    public class TicketResolvedRuleRepository : ITicketRule
    {
        public override void Define()
        {
            When()
                .Or(x=>x
                .Exists<Ticket>(t => t.state == State.Resolved)
                .Exists<Ticket>(t => t.state == State.Closed)
                )
                .Not<Ticket>(t => t.solution != null);
                Then()
                .Do(ctx => this.ThrowException(ctx));
        }

        public void ThrowException(IContext ctx)
        {
            var validationsError = new BusinessValidationError()
            {
                Error = "No solution affected to the ticket\n",
                ErrorCode = BusinessErrorCodes.SolutionRequired,
                Fields = new List<string> { nameof(Ticket.id) }
            };
            ctx.Insert(validationsError);
        }
    }
}