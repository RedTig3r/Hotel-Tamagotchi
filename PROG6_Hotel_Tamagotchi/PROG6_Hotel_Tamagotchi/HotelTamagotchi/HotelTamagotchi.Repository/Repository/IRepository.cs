using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTamagotchi.Models.Repository
{

    public interface IRepository<T>
    {

        ICollection<T> GetAll();

        ICollection<T> GetAllWhereId(object id);

        T GetWhereId(object id);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

    }


}
