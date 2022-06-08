using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Models;

namespace Restuarant.DataAccess
{
    public class RestaurantDBContext : DbContext
    {
        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
