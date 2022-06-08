using RestaurantWeb.Models;

namespace RestaurantWeb.Repository.IRepository
{
    internal interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

        void Save();
    }
}
