using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Domain.Repository
{
    public class TamagotchiRepository : IRepository<Tamagotchi>
    {

        public ICollection<Tamagotchi> GetAll()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.Tamagotchis
                    .Include(t => t.HotelBooking)
                    .Include(t => t.HotelBooking.HotelRoom)
                    .Include(t => t.PlayerUser)
                    .ToList();
            }
        }

        public void Add(Tamagotchi entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.Tamagotchis.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Tamagotchi entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }

        public void Edit(Tamagotchi entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }


        public Tamagotchi GetWhereId(int? id)
        {
            if (id != null || id != 0)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {
                    return context.Tamagotchis
                        .Include(t => t.HotelBooking)
                        .Include(t => t.HotelBooking.HotelRoom)
                        .Include(t => t.PlayerUser)
                        .Where(t => t.TamagotchiId == id)
                        .FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        //Extra

        public ICollection<Tamagotchi> GetAllTamagotchisWherePlayerId(int playerUserId)
        {
            if (playerUserId != 0)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    return context.Tamagotchis
                        .Include(t => t.HotelBooking)
                        .Include(t => t.HotelBooking.HotelRoom)
                        .Include(t => t.PlayerUser)
                        .Where(t => t.PlayerUser.PlayerUserId == playerUserId)
                        .ToList();
                }
            }
            else
            {
                return null;
            }
        }

        public ICollection<Tamagotchi> GetAllTamagotchisALiveAndNoHotelRoom()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.Tamagotchis
                    .Include(t => t.HotelBooking)
                    .Include(t => t.HotelBooking.HotelRoom)
                    .Include(t => t.PlayerUser)
                    .Where(t => t.IsALive == true && t.HotelBooking == null)
                    .ToList();
            }
        }


    }
}