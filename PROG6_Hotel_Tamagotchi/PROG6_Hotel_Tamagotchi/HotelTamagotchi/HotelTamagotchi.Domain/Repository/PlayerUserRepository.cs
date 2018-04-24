using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Domain.Repository
{
    public class PlayerUserRepository : IRepository<PlayerUser>
    {
        public ICollection<PlayerUser> GetAll()
        {
            using (var context = new HotelTamagotchiDBEntities())
            {
                return context.PlayerUsers.ToList();
            }
        }

        public void Add(PlayerUser entity)
        {
            if (entity != null)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {

                    context.PlayerUsers.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(PlayerUser entity)
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

        public void Edit(PlayerUser entity)
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

        public PlayerUser GetWhereId(int? id)
        {
            if (id != null || id != 0)
            {
                using (var context = new HotelTamagotchiDBEntities())
                {
                    return context.PlayerUsers
                        .Where(p => p.PlayerUserId == id)
                        .FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }
    }
}