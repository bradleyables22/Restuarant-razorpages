using RestaurantWeb.Models;
using RestaurantWeb.Repository.IRepository;
using RestaurantWeb.Data;

namespace RestaurantWeb.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly RestaurantDBContext _restaurantDBContext;

        public CategoryRepository(RestaurantDBContext restaurantDBContext) : base(restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext;
        }

        public void Save()
        {
            _restaurantDBContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var catObjDB = _restaurantDBContext.Categories.FirstOrDefault(c => c.Id == category.Id);

            catObjDB.Name = category.Name;
            catObjDB.DisplayOrder = category.DisplayOrder;
        }
    }
}
