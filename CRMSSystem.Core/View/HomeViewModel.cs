using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class HomeViewModel
    {
        public int HighPrioritycount { get; set; }
        public int LowPrioritycount { get; set; }
        public int ImmediatePrioritycount { get; set; }
        public int MediumPrioritycount { get; set; }
    }
}
