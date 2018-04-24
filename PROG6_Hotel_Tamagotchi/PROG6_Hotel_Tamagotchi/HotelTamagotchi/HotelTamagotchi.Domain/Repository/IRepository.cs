using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTamagotchi.Domain.Repository
{

    public interface IRepository<T>
    {

        ICollection<T> GetAll();

        T GetWhereId(int? id);

         void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

  

    }


}
