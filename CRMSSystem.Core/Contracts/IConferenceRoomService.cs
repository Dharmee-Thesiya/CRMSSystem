using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IConferenceRoomService
    {
        List<ConferenceRoom> GetConferenceRooms();
        ConferenceRoomViewModel GetConferenceRoom(Guid Id);
        string CreateConferenceRoom(ConferenceRoomViewModel model);
        void EditConferenceRoom(ConferenceRoomViewModel model);
        void DeleteConferenceRoom(ConferenceRoomViewModel model);
    }
}
