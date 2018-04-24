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
    public class PlayerUserRepository : IRepository<PlayerUser>
    {

        private readonly HotelTamagotchiContext _context;

        public PlayerUserRepository(HotelTamagotchiContext context)
        {
            this._context = context;
        }

        public ICollection<PlayerUser> GetAll()
        {
            try
            {
                return _context.PlayerUsers.ToList();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        public void Add(PlayerUser entity)
        {
            try
            {
                _context.PlayerUsers.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }

        }

        public void Delete(PlayerUser entity)
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

        public void Edit(PlayerUser entity)
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

        public ICollection<PlayerUser> GetAllWhereId(object id)
        {
            try
            {
                return _context.PlayerUsers.Where(p => p.PlayerUserId == (int?)id).ToList();
            }
            catch (DbEntityValidationException e)
            {
                throw e;

            }
        }

        public PlayerUser GetWhereId(object id)
        {
            try
            {
                return _context.PlayerUsers.Where(p => p.PlayerUserId == (int?)id).First();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }


    }
}