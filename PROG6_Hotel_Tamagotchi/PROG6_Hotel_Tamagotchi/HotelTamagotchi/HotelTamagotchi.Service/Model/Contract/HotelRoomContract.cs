using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace HotelTamagotchi.Service.Model.Contract
{
    [DataContract]
    public class HotelRoomContract
    {

        public HotelRoomContract()
        {

        }

        public HotelRoomContract(HotelRoom hotelRoom)
        {
            this.HotelRoomName = hotelRoom.HotelRoomName;
            this.RoomSize = hotelRoom.RoomSize;
            this.RoomType = hotelRoom.RoomType;
        }


        internal HotelRoom ToHotelRoom()
        {
            return new HotelRoom()
            {
                HotelRoomName = this.HotelRoomName,
                RoomSize = this.RoomSize,
                RoomType = this.RoomType
            };
        }

        [DataMember]
        public string HotelRoomName { get; set; }

        [DataMember]
        public int RoomSize { get; set; }

        [DataMember]
        public string RoomType { get; set; }

        public HotelRoomType HotelRoomType { get; set; }

        public IEnumerable<Tamagotchi> Tamagotchis { get; set; }




    }
}