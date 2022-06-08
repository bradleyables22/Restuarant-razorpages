using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWeb.Data;
using RestaurantWeb.Models;

namespace RestaurantWeb.Pages.Admin.FoodType
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantDBContext _restaurantDBContext;
        public IEnumerable<Models.FoodType> foodTypes;

        public void OnGet()
        {
        }
    }
}
