using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Domain.Repository
{
    public class HotelRoomRepository : IRepository<HotelRoom>
    {

        public ICollection<HotelRoom> GetAll()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.HotelRooms
                    .Include(h => h.HotelBooking)
                    .Include(h => h.HotelRoomType)
                    .Include(h => h.HotelRoomSize)
                    .ToList();
            }
        }

        public void Add(HotelRoom entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.HotelRooms.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(HotelRoom entity)
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

        public void Edit(HotelRoom entity)
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

        public HotelRoom GetWhereId(int? id)
        {
            if (id != null || id != 0)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    return context.HotelRooms
                        .Include(h => h.HotelBooking)
                        .Include(h => h.HotelRoomType)
                        .Include(h => h.HotelRoomSize)
                        .Where(t => t.HotelRoomId == id)
                        .FirstOrDefault();
                }

            }
            else
            {
                return null;
            }
        }


        public ICollection<HotelRoom> GetAllHotelRoomsWhereBookingIsNull()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.HotelRooms
                    .Include(h => h.HotelBooking)
                    .Include(h => h.HotelRoomType)
                    .Include(h => h.HotelRoomSize)
                    .Where(h => h.HotelBooking == null)
                    .ToList();
            }
        }
    }
}