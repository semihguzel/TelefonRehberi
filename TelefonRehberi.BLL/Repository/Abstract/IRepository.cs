using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.BLL.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetEntity();
        ICollection<T> GetAll();
        T GetById(int? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
