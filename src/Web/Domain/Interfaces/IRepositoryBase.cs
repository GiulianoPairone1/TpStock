using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        T FindByCondition(Func<T, bool> condition);
        T add(T entity);
        T update(T entity);
    }
}
