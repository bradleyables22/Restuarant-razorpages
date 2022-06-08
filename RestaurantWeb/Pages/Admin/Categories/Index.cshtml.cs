using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWeb.Models;

namespace RestaurantWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantDBContext _restaurantDBContext;
        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext;
        }


        public void OnGet()
        {
            Categories = _restaurantDBContext.Categories;
        }
    }
}
