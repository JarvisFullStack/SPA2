using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> expression);
        T Get(int id);
        bool Save(T entity);
        bool Modify(T entity);
        bool Delete(int id);
    }
}
