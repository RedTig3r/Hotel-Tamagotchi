using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Models.ViewModel
{
    public class TamagotchiVM
    {

        private Tamagotchi _tamagotchi;

        public TamagotchiVM()
        {
            _tamagotchi = new Tamagotchi();
        }

        public TamagotchiVM(Tamagotchi tamagotchi)
        {
            this._tamagotchi = tamagotchi;
        }

        internal Tamagotchi ToModel()
        {
            return _tamagotchi;
        }


        [Required]
        [DisplayName("Tamagotchi Id")]
        public int TamagotchiId
        {
            get { return _tamagotchi.TamagotchiId; }
            set { _tamagotchi.TamagotchiId = value; }
        }


        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name
        {
            get { return _tamagotchi.Name; }
            set { _tamagotchi.Name = value; }
        }

        [Required]
        [DisplayName("Is a live")]
        public bool IsALive
        {
            get { return _tamagotchi.IsALive; }
            set { _tamagotchi.IsALive = value; }
        }

        [Required]
        [Range(0, int.MaxValue)]
        public int Age
        {
            get { return _tamagotchi.Age; }
            set { _tamagotchi.Age = value; }
        }

        [Required]
        [Range(0, int.MaxValue)]
        public int Money
        {
            get { return _tamagotchi.Money; }
            set { _tamagotchi.Money = value; }
        }

        [Required]
        [Range(0, int.MaxValue)]
        public int Level
        {
            get { return _tamagotchi.Level; }
            set { _tamagotchi.Level = value; }
        }

        [Required]
        [Range(0, 100)]
        public int Health
        {
            get { return _tamagotchi.Health; }
            set { _tamagotchi.Health = value; }
        }

        [Required]
        [Range(0, int.MaxValue)]
        public int Boredom
        {
            get { return _tamagotchi.Boredom; }
            set { _tamagotchi.Boredom = value; }
        }

        [Required]
        [DisplayName("Player User Id")]
        public int PlayerUserId
        {
            get { return _tamagotchi.PlayerUserId; }
            set { _tamagotchi.PlayerUserId = value; }
        }


        [DisplayName("Hotel room Id")]
        public Nullable<int> HotelRoomId
        {
            get { return _tamagotchi.HotelRoomId; }
            set { _tamagotchi.HotelRoomId = value; }
        }


        [DisplayName("Hotel room")]
        public HotelBooking HotelBooking
        {
            get { return _tamagotchi.HotelBooking; }
            set { _tamagotchi.HotelBooking = value; }
        }

        [DisplayName("Player user name")]
        public PlayerUser PlayerUser
        {
            get { return _tamagotchi.PlayerUser; }
            set { _tamagotchi.PlayerUser = value; }
        }

        // Extra voor displayname
        [DisplayName("Hotel room name")]
        public string HotelRoomName
        {
            get
            {
                if (HotelBooking != null)
                { return _tamagotchi.HotelBooking.HotelRoom.HotelRoomName; }
                else
                { return null; }
            }
            set { _tamagotchi.HotelBooking.HotelRoom.HotelRoomName = value; }
        }

        [DisplayName("Player username")]
        public string PlayerUserName
        {
            get { return _tamagotchi.PlayerUser.PlayerUserName; }
            set { _tamagotchi.PlayerUser.PlayerUserName = value; }
        }



    }
}