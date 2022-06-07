using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWeb.Data;
using RestaurantWeb.Models;

namespace RestaurantWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        [BindProperty] public Category category { get; set; }

        private readonly RestaurantDBContext _restaurantDBContext;
        public CreateModel(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        { 
           await _restaurantDBContext.Categories.AddAsync(category);
           await _restaurantDBContext.SaveChangesAsync();
           return RedirectToPage("Index");
        }
    }
}
