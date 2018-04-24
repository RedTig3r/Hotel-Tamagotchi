using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;

namespace HotelTamagotchi.Models.RoomFactory
{
    public class FightRoom : BaseRoom
    {

        // Kosten: Gratis (nul centjes)
        // Effect-winnaar: +20 centjes per verliezer
        // Effect-winnaar: +1 Level
        // Effect-verliezer: -20 centjes
        // Effect-verliezer: -30 Gezondheid

        public override void Overnight(ICollection<Tamagotchi> tamagotchis)
        {
            int i = 0;

            Random rand = new Random();
            int winner = rand.Next(0, tamagotchis.Count + 1);

            foreach (var t in tamagotchis)
            {
                if (i == winner)
                {
                    t.Level += 1;
                    t.Money += 20;
                }
                else
                {
                    if (t.Money >= 20)
                    {
                        t.Money -= 20;
                    }
                    if (t.Health > 30)
                    {
                        t.Health -= 30;
                    }
                    else
                    {
                        t.Health = 0;
                    }
                }
                i++;
            }
            base.Overnight(tamagotchis);
        }

    }
}