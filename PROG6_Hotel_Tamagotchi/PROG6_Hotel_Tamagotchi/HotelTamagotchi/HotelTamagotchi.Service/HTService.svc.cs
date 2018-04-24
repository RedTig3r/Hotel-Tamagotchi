using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HotelTamagotchi.Service.Model.Contract;
using HotelTamagotchi.Domain.Repository;

namespace HotelTamagotchi.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class HTService : IHTService
    {

        private readonly HotelRoomRepository _hotelRoomRepository;
        private readonly HotelRoomTypeRepository _hotelRoomTypeRepository;
        private readonly PlayerUserRepository _playerUserRepository;
        private readonly TamagotchiRepository _tamagotchiRepository;



        public HTService(HotelRoomRepository hotelRoomRepository,
                         HotelRoomTypeRepository hotelRoomTypeRepository,
                         PlayerUserRepository playerUserRepository,
                         TamagotchiRepository tamagotchiRepository)
        {
            this._hotelRoomRepository = hotelRoomRepository;
            this._hotelRoomTypeRepository = hotelRoomTypeRepository;
            this._playerUserRepository = playerUserRepository;
            this._tamagotchiRepository = tamagotchiRepository;
        }

        public PlayerUser CreatePlayerUser(PlayerUser composite)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayerUser(PlayerUser composite)
        {
            throw new NotImplementedException();
        }

        public ICollection<PlayerUser> GetAllPlayerUser()
        {
            throw new NotImplementedException();
        }

        public void HotelRoomAdd(HotelRoomContract contract)
        {
            throw new NotImplementedException();
        }

        public void HotelRoomDelete(HotelRoomContract contract)
        {
            throw new NotImplementedException();
        }

        public void HotelRoomEdit(HotelRoomContract contract)
        {
            throw new NotImplementedException();
        }

        public ICollection<HotelRoomContract> HotelRoomGetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<HotelRoomContract> HotelRoomGetAllWhereId(int? id)
        {
            throw new NotImplementedException();
        }

        public HotelRoomContract HotelRoomGetWhereId(int? id)
        {
            throw new NotImplementedException();
        }

        public void PlayerUserAdd(PlayerUserContract contract)
        {
            throw new NotImplementedException();
        }

        public void PlayerUserDelete(PlayerUserContract contract)
        {
            throw new NotImplementedException();
        }

        public void PlayerUserEdit(PlayerUserContract contract)
        {
            throw new NotImplementedException();
        }

        public ICollection<PlayerUserContract> PlayerUserGetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<PlayerUserContract> PlayerUserGetAllWhereId(int? id)
        {
            throw new NotImplementedException();
        }

        public PlayerUserContract PlayerUserGetWhereId(int? id)
        {
            throw new NotImplementedException();
        }

        public void TamagotchiAdd(TamagotchiContract contract)
        {
            throw new NotImplementedException();
        }

        public void TamagotchiDelete(TamagotchiContract contract)
        {
            throw new NotImplementedException();
        }

        public void TamagotchiEdit(TamagotchiContract contract)
        {
            throw new NotImplementedException();
        }

        public ICollection<TamagotchiContract> TamagotchiGetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<TamagotchiContract> TamagotchiGetAllWhereId(int? id)
        {
            throw new NotImplementedException();
        }

        public TamagotchiContract TamagotchiGetWhereId(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
