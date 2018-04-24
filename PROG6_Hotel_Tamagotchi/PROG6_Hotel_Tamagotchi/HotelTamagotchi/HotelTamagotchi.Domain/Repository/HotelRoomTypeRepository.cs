using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Domain.Repository
{
    public class HotelRoomTypeRepository : IRepository<HotelRoomType>
    {
        public ICollection<HotelRoomType> GetAll()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.HotelRoomTypes.ToList();
            }
        }

        public void Add(HotelRoomType entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.HotelRoomTypes.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(HotelRoomType entity)
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

        public void Edit(HotelRoomType entity)
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


        public HotelRoomType GetWhereId(int? id)
        {
            return null;
        }

    }
}