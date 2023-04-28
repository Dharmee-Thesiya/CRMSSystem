using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Models
{
   public static class Constants
    {
        public static bool  All { get; set; }
        
        public static class ConfigName
        {
            public static string Priority = "TicketPriority";
            public static string Status = "TicketStatus";
            public static string Type = "TicketType";
            
        }
    }
}
