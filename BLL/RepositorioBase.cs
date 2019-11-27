using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {       

        public RepositorioBase()
        {            
        }

        public virtual bool Delete(int id)
        {
            bool ok = false;
            try
            {
				Contexto _context = new Contexto();
                T entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(entity);

                if (_context.SaveChanges() > 0)
                {
                    ok = true;
                }
                _context.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return ok;
        }

        public void Dispose()
        {
            
        }

        public virtual T Get(int id)
        {
            T entity;
            try
            {
				Contexto _context = new Contexto();
				entity = _context.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> list = new List<T>();
            try
            {
				Contexto _context = new Contexto();
				list = _context.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public virtual bool Modify(T entity)
        {
            bool ok = false;
            try
            {
				Contexto _context = new Contexto();
				_context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (_context.SaveChanges() > 0)
                {
                    ok = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ok;
        }

        public virtual bool Save(T entity)
        {
            bool ok = false;
            try
            {
				Contexto _context = new Contexto();
				if (_context.Set<T>().Add(entity) != null)
                {
                    _context.SaveChanges();
                    ok = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ok;
        }

    }
}
