using HotelTamagotchi.Domain.Model;
using HotelTamagotchi.Domain.Repository;
using HotelTamagotchi.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace HotelTamagotchi.Models.RoomFactory
{
    public class RoomFactory
    {

        private readonly HotelBookingRepository _hotelBookingRepository;
        private readonly HotelRoomRepository _hotelRoomRepository;
        private readonly TamagotchiRepository _tamagotchiRepository;


        private Dictionary<string, IRoom> _rooms;

        public RoomFactory(
            HotelBookingRepository hotelBookingRepository,
            HotelRoomRepository hotelRoomRepository,
            TamagotchiRepository tamagotchiRepository,
            Dictionary<string, IRoom> rooms
            )
        {
            this._hotelBookingRepository = hotelBookingRepository;
            this._hotelRoomRepository = hotelRoomRepository;
            this._tamagotchiRepository = tamagotchiRepository;
            this._rooms = rooms;
            _rooms["Rest room"] = new RestRoom();
            _rooms["Game room"] = new GameRoom();
            _rooms["Fight room"] = new FightRoom();
            _rooms["Work room"] = new WorkRoom();
            _rooms["Love room"] = new LoveRoom();
            _rooms["No room"] = new NoRoom();
        }

        public void HotelRoomBookingStayOverNight(string roomType, ICollection<Tamagotchi> tamagotchis)
        {
            try
            {
                _rooms[roomType].Overnight(tamagotchis);
            }
            catch
            {
                _rooms["No room"].Overnight(tamagotchis);
            }
        }


        public void ChangeTamagotchiStats()
        {
            // tamagotchis with NO booking
            var tamagotchis = _tamagotchiRepository.GetAllTamagotchisALiveAndNoHotelRoom();
            this.HotelRoomBookingStayOverNight("No room", tamagotchis);

            foreach (var tamagotchi in tamagotchis)
            {
                _tamagotchiRepository.Edit(tamagotchi);
            }

            // tamagotchis with booking
            var hotelBookingsVM = _hotelBookingRepository.GetAll().Select(h => new HotelBookingVM(h)).ToList();

            foreach (var hotelBookingVM in hotelBookingsVM)
            {
                this.HotelRoomBookingStayOverNight(hotelBookingVM.RoomType, hotelBookingVM.Tamagotchis);

                foreach (var tamagotchi in hotelBookingVM.Tamagotchis)
                {
                    _tamagotchiRepository.Edit(tamagotchi);
                }
                _hotelBookingRepository.Delete(hotelBookingVM.ToModel());
            }
        }

    }
}