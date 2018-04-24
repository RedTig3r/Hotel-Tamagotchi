using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Models.ViewModel
{
    public class HotelRoomVM
    {

        private HotelRoom _hotelRoom;

        public HotelRoomVM()
        {
            _hotelRoom = new HotelRoom();
        }

        public HotelRoomVM(HotelRoom hotelRoom)
        {
            this._hotelRoom = hotelRoom;
        }
        internal HotelRoom ToModel()
        {
            return _hotelRoom;
        }

        [Key]
        [Required]
        [DisplayName("Hotel room Id")]
        public int HotelRoomId
        {
            get { return _hotelRoom.HotelRoomId; }
            set { _hotelRoom.HotelRoomId = value; }
        }

        [Required]
        [DisplayName("Hotel room name")]
        [MinLength(3)]
        [MaxLength(50)]
        public string HotelRoomName
        {
            get { return _hotelRoom.HotelRoomName; }
            set { _hotelRoom.HotelRoomName = value; }
        }

        [Required]
        [DisplayName("Room size")]
        [RegularExpression("^[235]$", ErrorMessage = "Room size must be 2,3 or 5")]
        public int RoomSize
        {
            get { return _hotelRoom.RoomSize; }
            set { _hotelRoom.RoomSize = value; }
        }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("Hotel room type")]
        public string RoomType
        {
            get { return _hotelRoom.RoomType; }
            set { _hotelRoom.RoomType = value; }
        }


        [DisplayName("Hotel room type")]
        public HotelRoomType HotelRoomType
        {
            get { return _hotelRoom.HotelRoomType; }
            set { _hotelRoom.HotelRoomType = value; }
        }

        [DisplayName("Hotel room size")]
        public HotelRoomSize HotelRoomSize
        {
            get { return _hotelRoom.HotelRoomSize; }
            set { _hotelRoom.HotelRoomSize = value; }
        }

    }
}