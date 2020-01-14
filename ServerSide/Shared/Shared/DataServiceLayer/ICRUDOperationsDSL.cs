using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataServiceLayer
{
    public interface ICRUDOperationsDSL<T>
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        int Update(T entity);
        int Add(T entity);
        int Delete(long id);
    }
}
