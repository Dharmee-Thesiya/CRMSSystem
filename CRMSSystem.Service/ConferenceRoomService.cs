using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Service
{
    public class ConferenceRoomService : IConferenceRoomService
    {
        IMRepository<ConferenceRoom> _conferenceRoomRepository;
        public ConferenceRoomService(IMRepository<ConferenceRoom> conferenceRoomRepository)
        {
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public string CreateConferenceRoom(ConferenceRoomViewModel model)
        {
            if (_conferenceRoomRepository.Collection().Where(r => r.Name == model.Name && !r.IsDeleted).Any())
            {
                return "ConferenceRoom Already Exist";
            }

            ConferenceRoom conferenceRoom = new ConferenceRoom();
            conferenceRoom.Capacity = model.Capacity;
            conferenceRoom.Name = model.Name;

            _conferenceRoomRepository.Insert(conferenceRoom);
            _conferenceRoomRepository.Commit();
            return null;
        }

        public void DeleteConferenceRoom(ConferenceRoomViewModel model)
        {
            ConferenceRoom conferenceRoom = _conferenceRoomRepository.Collection().Where(cr => cr.Id == model.Id).FirstOrDefault();
            conferenceRoom.IsDeleted = true;

            _conferenceRoomRepository.Update(conferenceRoom);
            _conferenceRoomRepository.Commit();
        }

        public void EditConferenceRoom(ConferenceRoomViewModel model)
        {
            ConferenceRoom conferenceRoom = _conferenceRoomRepository.Collection().Where(cr => cr.Id == model.Id).FirstOrDefault();
            conferenceRoom.Name = model.Name;
            conferenceRoom.Capacity = model.Capacity;
            conferenceRoom.UpdatedOn = DateTime.Now;

            _conferenceRoomRepository.Update(conferenceRoom);
            _conferenceRoomRepository.Commit();
        }

        public ConferenceRoomViewModel GetConferenceRoom(Guid Id)
        {
            
            ConferenceRoom conferenceRoom = _conferenceRoomRepository.Find(Id);
            ConferenceRoomViewModel conferenceRoomViewModel = new ConferenceRoomViewModel();
            conferenceRoomViewModel.Name = conferenceRoom.Name;
            conferenceRoomViewModel.Capacity = conferenceRoom.Capacity;
            return conferenceRoomViewModel;
        }

        public List<ConferenceRoom> GetConferenceRooms()
        {
            return _conferenceRoomRepository.Collection().Where(cr => !cr.IsDeleted).ToList();
        }
    }
}
