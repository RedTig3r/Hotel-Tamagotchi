using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTamagotchi.Domain.Repository
{
    public class HotelRoomSizeRepository : IRepository<HotelRoomSize>
    {

        public ICollection<HotelRoomSize> GetAll()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.HotelRoomSizes.ToList();
            }
        }

        public void Add(HotelRoomSize entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.HotelRoomSizes.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(HotelRoomSize entity)
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

        public void Edit(HotelRoomSize entity)
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


        public HotelRoomSize GetWhereId(int? id)
        {
            return null;
        }
    }
}