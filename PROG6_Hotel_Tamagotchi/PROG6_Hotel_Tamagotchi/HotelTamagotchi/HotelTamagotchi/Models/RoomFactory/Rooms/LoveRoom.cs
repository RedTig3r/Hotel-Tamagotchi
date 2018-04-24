using HotelTamagotchi.Domain.Model;
using System.Collections.Generic;

namespace HotelTamagotchi.Models.RoomFactory
{
    public class LoveRoom : BaseRoom
    {

        // Eigen kamer
        // Kosten: 30 centjes
        // Effect: + 40 Gezondheid
        // Effect : Boredom = 0

        public override void Overnight(ICollection<Tamagotchi> tamagotchis)
        {
            foreach (var t in tamagotchis)
            {
                if (t.Health <= 60)
                {
                    t.Health += 40;
                }
                else
                {
                    t.Health = 100;
                }
                if(t.Money >= 30)
                {
                    t.Money -= 30;
                }
                t.Boredom = 0;
            }
            base.Overnight(tamagotchis);
        }

    }
}