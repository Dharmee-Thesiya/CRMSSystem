using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface ITicketService
    {
        
        Ticket CreateTicket(TicketViewModel model);
        
        List<DropDown> SetDropDownValues(string configName);
       
    }
}
