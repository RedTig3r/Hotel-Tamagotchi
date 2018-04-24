using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Models.RoomFactory
{
    public abstract class BaseRoom : IRoom
    {

        // actie die gebeurt bij alle kamers
        // Verhoog het level van de Tamagotchi’s met 1
        //Als verveling groter dan of gelijk aan 70 -> Gezondheid -20
        // Als gezondheid gelijk aan 0 -> Tamagotchi is dood

        public virtual void Overnight(ICollection<Tamagotchi> tamagotchis)
        {
            foreach (var t in tamagotchis)
            {
                t.Age += 1;
                t.Level += 1;

                if (t.Boredom > 70)
                {
                    if (t.Health > 20)
                    {
                        t.Health -= 20;
                    }
                    else
                    {   
                        t.Health = 0;
                    }      
                }

                if (t.Health == 0)
                {
                    t.IsALive = false;
                }
            }
        }

    }
}
