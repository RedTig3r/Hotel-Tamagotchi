using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTamagotchi.Domain.Repository
{
    public class HotelBookingRepository : IRepository<HotelBooking>
    {

        public ICollection<HotelBooking> GetAll()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.HotelBookings
                    .Include(h => h.HotelRoom)
                    .Include(h => h.HotelRoom.HotelRoomType)
                    .Include(h => h.HotelRoom.HotelRoomSize)
                    .Include(h => h.Tamagotchis)
                    .ToList();
            }
        }

        public void Add(HotelBooking entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.HotelBookings.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(HotelBooking entity)
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

        public void Edit(HotelBooking entity)
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

        public HotelBooking GetWhereId(int? id)
        {

            if (id != null || id != 0)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {
                    return context.HotelBookings
                        .Include(h => h.HotelRoom)
                        .Include(h => h.HotelRoom.HotelRoomType)
                        .Include(h => h.HotelRoom.HotelRoomSize)
                        .Include(h => h.Tamagotchis)
                        .Where(h => h.HotelRoomId == id)
                        .FirstOrDefault();
                }

            }
            else
            {
                return null;
            }
        }


        // Extra
        public void SetAllTamagotchiHotelRoomToNull(HotelBooking entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {
                    foreach (var tamagotchi in entity.Tamagotchis)
                    {
                        tamagotchi.HotelBooking = null;
                        tamagotchi.HotelRoomId = null;
                        context.Entry(tamagotchi).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}