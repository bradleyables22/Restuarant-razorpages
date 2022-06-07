using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Models;

namespace RestaurantWeb.Data
{
    public class RestaurantDBContext : DbContext
    {
        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
