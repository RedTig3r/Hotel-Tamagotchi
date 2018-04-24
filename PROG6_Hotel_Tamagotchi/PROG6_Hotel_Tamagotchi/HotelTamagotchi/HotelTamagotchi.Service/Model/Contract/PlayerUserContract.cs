using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace HotelTamagotchi.Service.Model.Contract
{
    [DataContract]
    public class PlayerUserContract
    {

        public PlayerUserContract()
        {
        }

        public PlayerUserContract(PlayerUser playerUser)
        {
            this.PlayerUserName = playerUser.PlayerUserName;
            this.PlayerUserRoll = playerUser.PlayerUserRoll;
            this.Tamagotchis = playerUser.Tamagotchis;
        }


        internal PlayerUser ToPlayerUser()
        {
            return new PlayerUser()
            {
                PlayerUserName = this.PlayerUserName,
                PlayerUserRoll = this.PlayerUserRoll,
                Tamagotchis = this.Tamagotchis
            };
        }

        [DataMember]
        public string PlayerUserName { get; set; }

        [DataMember]
        public string PlayerUserRoll { get; set; }

        [DataMember]
        public ICollection<Tamagotchi> Tamagotchis { get; set; }




    }
}