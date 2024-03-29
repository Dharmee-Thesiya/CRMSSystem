﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Models
{
    public class Ticket:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AssignId { get; set; }
        public Guid TypeId { get; set; }
        public Guid PriorityId { get; set; }
        public Guid StatusId { get; set; }
    }
}
