using HotelTamagotchi.Domain.Model;
using HotelTamagotchi.Service.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Service.Model
{
    public class HotelTamagotchiContext : DbContext
    {
        public HotelTamagotchiContext() : base("name=Local")
        {
            Database.SetInitializer(new HotelTamagotchiContextInitializer());
        }


        public DbSet<PlayerUser> PlayerUsers { get; set; }

        public DbSet<Tamagotchi> Tamagotchis { get; set; }

        public DbSet<HotelRoomType> HotelRoomTypes { get; set; }

        public DbSet<HotelRoom> HotelRooms{ get; set; }



    }
}