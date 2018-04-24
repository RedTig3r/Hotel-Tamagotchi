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
    public class HotelRoomRepository : IRepository<HotelRoom>
    {

        private readonly HotelTamagotchiContext _context;

        public HotelRoomRepository(HotelTamagotchiContext context)
        {
            this._context = context;
        }

        public ICollection<HotelRoom> GetAll()
        {
            return _context.HotelRooms.Include(h => h.HotelRoomType).ToList();
        }

        public void Add(HotelRoom entity)
        {
            try
            {
                _context.HotelRooms.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }

        }

        public void Delete(HotelRoom entity)
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

        public void Edit(HotelRoom entity)
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

        public ICollection<HotelRoom> GetAllWhereId(object id)
        {
            try
            {
                return _context.HotelRooms.Include(h => h.HotelRoomType).Where(h => h.HotelRoomId == (int?)id).ToList();
            }
            catch (DbEntityValidationException e)
            {
                throw e;

            }

        }

        public HotelRoom GetWhereId(object id)
        {
            try
            {
                return _context.HotelRooms.Include(h => h.HotelRoomType).Where(t => t.HotelRoomId == (int?)id).First();
            }
            catch (DbEntityValidationException e)
            {
                throw e;

            }

        }


    }
}