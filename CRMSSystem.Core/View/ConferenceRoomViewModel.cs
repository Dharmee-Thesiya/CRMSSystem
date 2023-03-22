using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class ConferenceRoomViewModel
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guid? Id { get; set; }
    }
}
