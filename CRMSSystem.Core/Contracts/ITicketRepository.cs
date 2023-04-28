﻿using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> Collection();
        void Insert(Ticket ticket);
        void Commit();
        Ticket Find(Guid Id);
        List<TicketViewModel> GetTicket();
        TicketViewModel GetTicketById(Guid Id);
    }
}
