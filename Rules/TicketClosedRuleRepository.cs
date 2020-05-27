using NRules.RuleModel;
using System.Collections.Generic;
using WebAPIRuleEngine.Codes;
using WebAPIRuleEngine.Model;
using WebAPIRuleEngine.Validations;

namespace WebAPIRuleEngine.Rules
{
    public class TicketClosedRuleRepository : ITicketRule
    {
        public override void Define()
        {
            When()
                .Exists<Ticket>(t => t.state == State.Closed)
                .Not<Ticket>(t => t.usage != null);
            Then()
            .Do(ctx => this.ThrowException(ctx));
        }

        public void ThrowException(IContext ctx)
        {
            var validationsError = new BusinessValidationError()
            {
                Error = "No usage affected to the ticket\n",
                ErrorCode = BusinessErrorCodes.UsageRequired,
                Fields = new List<string> { nameof(Ticket.id) }
            };
            ctx.Insert(validationsError);
        }
    }

}