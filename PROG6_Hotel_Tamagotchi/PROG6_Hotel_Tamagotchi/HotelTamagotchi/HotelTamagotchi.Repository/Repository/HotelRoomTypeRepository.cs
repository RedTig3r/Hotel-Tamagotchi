using HotelTamagotchi.Domain.Model;
using HotelTamagotchi.Service.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Models.Repository
{
    public class HotelRoomTypeRepository : IRepository<HotelRoomType>
    {
        private readonly HotelTamagotchiContext _context;

        public HotelRoomTypeRepository(HotelTamagotchiContext context)
        {
            this._context = context;
        }


        public ICollection<HotelRoomType> GetAll()
        {
            try
            {
                return _context.HotelRoomTypes.ToList();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        public void Add(HotelRoomType entity)
        {
            try
            {
                _context.HotelRoomTypes.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }

        }

        public void Delete(HotelRoomType entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }

        }

        public void Edit(HotelRoomType entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }

        }

        public ICollection<HotelRoomType> GetAllWhereId(object id)
        {
            try
            {
                return _context.HotelRoomTypes.Where(h => h.RoomType == (string)id).ToList();
            }
            catch (DbEntityValidationException e)
            {
                throw e;

            }

        }

        public HotelRoomType GetWhereId(object id)
        {
            try
            {
                return _context.HotelRoomTypes.Where(t => t.RoomType == (string)id).First();
            }
            catch (DbEntityValidationException e)
            {
                throw e;

            }
        }

    }
}