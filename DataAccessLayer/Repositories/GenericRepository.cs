using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal where T : class
    {
        
        public void Add(T entity)
        {
            using (var c = new Context())
            {
                c.Add(entity);
                c.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using var c = new Context();
            c.Remove(entity);
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Find<T>(id);
        }

        public List<T> GetAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            using var c = new Context();
            c.Update(entity);
            c.SaveChanges();
        }
    }
}
