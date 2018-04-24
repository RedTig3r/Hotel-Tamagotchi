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
    public class TamagotchiRepository : IRepository<Tamagotchi>
    {

        private readonly HotelTamagotchiContext _context;

        public TamagotchiRepository(HotelTamagotchiContext context)
        {
            this._context = context;
        }


        public ICollection<Tamagotchi> GetAll()
        {
            try
            {
                return _context.Tamagotchis.Include(t => t.HotelRoom).Include(t => t.PlayerUser).ToList();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        public void Add(Tamagotchi entity)
        {
            try
            {
                _context.Tamagotchis.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        public void Delete(Tamagotchi entity)
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

        public void Edit(Tamagotchi entity)
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



        public Tamagotchi GetWhereId(object id)
        {

            try
            {
                return _context.Tamagotchis.Include(t => t.HotelRoom).Include(t => t.PlayerUser).Where(t => t.TamagotchiId == (int?)id).First();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }


    }
}