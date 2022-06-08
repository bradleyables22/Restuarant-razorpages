using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Data;
using RestaurantWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace RestaurantWeb.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RestaurantDBContext _restaurantDBContext;
        internal DbSet<T> dbSet;

        public Repository(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext;
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
