using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
