using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace HotelTamagotchi.Service.Model.Contract
{

    [DataContract]
    public class TamagotchiContract
    {

        public TamagotchiContract()
        {
            this.IsALive = true;
            this.Age = 0;
            this.Money = 100;
            this.Level = 0;
            this.Health = 100;
            this.Boredom = 0;
        }

        public TamagotchiContract(Tamagotchi tamagotchi)
        {
            this.Name = tamagotchi.Name;
            this.IsALive = tamagotchi.IsALive;
            this.Age = tamagotchi.Age;
            this.Money = tamagotchi.Money;
            this.Level = tamagotchi.Level;
            this.Health = tamagotchi.Health;
            this.Boredom = tamagotchi.Boredom;
            this.PlayerUserId = tamagotchi.PlayerUserId;
     
        }

        internal Tamagotchi ToTamagotchi()
        {
            return new Tamagotchi()
            {
                Name = this.Name,
                IsALive = this.IsALive,
                Age = this.Age,
                Money = this.Money,
                Level = this.Level,
                Health = this.Health,
                Boredom = this.Boredom
            };
        }


        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsALive { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public int Money { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public int Health { get; set; }

        [DataMember]
        public int Boredom { get; set; }

        [DataMember]
        public int PlayerUserId { get; set; }

        [DataMember]
        public HotelRoomContract HotelRoom { get; set; }

        [DataMember]
        public PlayerUserContract PlayerUser { get; set; }




    }
}