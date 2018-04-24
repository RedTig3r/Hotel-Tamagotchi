using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;

namespace HotelTamagotchi.Models.RoomFactory
{
    public class WorkRoom : BaseRoom
    {

        //Effect: +10-60 centjes (random)
        //Effect: +20 Verveling

        public override void Overnight(ICollection<Tamagotchi> tamagotchis)
        {
            Random rand = new Random();

            foreach (var t in tamagotchis)
            {
                int money = rand.Next(1, 6);

                money *= 10;
                t.Money += money;

                t.Boredom += 20;
            }
            base.Overnight(tamagotchis);
        }


    }
}