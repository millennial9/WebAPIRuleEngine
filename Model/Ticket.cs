using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIRuleEngine.Model
{
    public class Ticket
    {
        public int id;
        public string desc;
        public State state;
        public string solution;
        public string usage;
        public DateTime updateAt;
        public Ticket(int id, string desc, State state)
        {
            this.id = id;
            this.desc = desc;
            this.state = state;
        }
    }
}
