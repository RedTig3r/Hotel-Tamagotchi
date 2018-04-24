using HotelTamagotchi.Domain.Model;
using System.Collections.Generic;

namespace HotelTamagotchi.Models.RoomFactory
{
    public class GameRoom : BaseRoom
    {
        // Kosten: 20 centjes
        // Verveling = 0
  
        public override void Overnight(ICollection<Tamagotchi> tamagotchis)
        {
            foreach (var t in tamagotchis)
            {
                if (t.Money >= 20)
                {
                    t.Money -= 20;
                }
                t.Boredom = 0;
            }
            base.Overnight(tamagotchis);
        }

    }
}