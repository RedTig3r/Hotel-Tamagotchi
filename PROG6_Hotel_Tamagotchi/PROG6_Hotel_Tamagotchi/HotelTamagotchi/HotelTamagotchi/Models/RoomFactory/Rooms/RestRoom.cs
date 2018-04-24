using HotelTamagotchi.Domain.Model;
using System.Collections.Generic;

namespace HotelTamagotchi.Models.RoomFactory
{
    public class RestRoom : BaseRoom
    {
        // Kosten: 10 centjes
        // Effect: + 20 Gezondheid
        // Effect: + 10 Verveling

        public override void Overnight(ICollection<Tamagotchi> tamagotchis)
        {
            foreach (var t in tamagotchis)
            {
                t.Money -= 10;
                if (t.Health <= 80)
                {
                    t.Health += 20;
                }
                else
                {
                    t.Health = 100;
                }

                t.Boredom += 10;
            }
            base.Overnight(tamagotchis);
        }


    }
}