using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace HotelTamagotchi.Service.Model
{
    public class HotelTamagotchiContextInitializer : DropCreateDatabaseAlways<HotelTamagotchiContext>
    {
        protected override void Seed(HotelTamagotchiContext context)
        {
            base.Seed(context);

            context.SaveChanges();
        }
    }
}