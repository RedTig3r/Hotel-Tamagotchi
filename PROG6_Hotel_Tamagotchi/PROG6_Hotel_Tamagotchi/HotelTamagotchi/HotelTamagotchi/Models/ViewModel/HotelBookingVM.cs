using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Models.ViewModel
{
    public class HotelBookingVM
    {
        private HotelBooking _hotelBooking;

        public HotelBookingVM()
        {
            _hotelBooking = new HotelBooking();
        }

        public HotelBookingVM(HotelBooking hotelBooking)
        {
            this._hotelBooking = hotelBooking;
        }

        internal HotelBooking ToModel()
        {
            return _hotelBooking;
        }

        [Key]
        [Required]
        [DisplayName("Hotel room Id")]
        public int HotelRoomId
        {
            get { return _hotelBooking.HotelRoomId; }
            set { _hotelBooking.HotelRoomId = value; }
        }

        [DisplayName("Hotel room")]
        public HotelRoom HotelRoom
        {
            get { return _hotelBooking.HotelRoom; }
            set { _hotelBooking.HotelRoom = value; }
        }


        [DisplayName("Hotel room name")]
        public string HotelRoomName
        {
            get { return _hotelBooking.HotelRoom.HotelRoomName; }
            set { _hotelBooking.HotelRoom.HotelRoomName = value; }
        }


        [DisplayName("Hotel room type")]
        public string RoomType
        {
            get { return _hotelBooking.HotelRoom.RoomType; }
            set { _hotelBooking.HotelRoom.RoomType = value; }
        }


        [DisplayName("Tamagotchi ids")]
        public int[] TamagotchisIds { get; set; }

        [DisplayName("Tamagotchis")]
        public ICollection<Tamagotchi> Tamagotchis
        {
            get { return _hotelBooking.Tamagotchis; }
            set { _hotelBooking.Tamagotchis = value; }
        }

    }
}