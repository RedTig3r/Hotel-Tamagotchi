using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Models.RoomFactory
{
    public class NoRoom : BaseRoom
    {
        // Effect: -20 Gezondheid
        // Effect: +20 Verveling

        public override void Overnight(ICollection<Tamagotchi> tamagotchis)
        {
            foreach (var t in tamagotchis)
            {
                if (t.Health >= 20)
                {
                    t.Health -= 20;
                }
                else
                {
                    t.Health = 0;
                }
                t.Boredom += 20;
            }
            base.Overnight(tamagotchis);
        }


    }
}