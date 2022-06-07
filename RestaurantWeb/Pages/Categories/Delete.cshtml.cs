using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWeb.Data;
using RestaurantWeb.Models;

namespace RestaurantWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty] public Category category { get; set; }

        private readonly RestaurantDBContext _restaurantDBContext;
        public DeleteModel(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext;
        }
        public void OnGet(int id)
        {
            category = _restaurantDBContext.Categories.Single(c => c.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            var reponseCat = await _restaurantDBContext.Categories.FindAsync(category.Id);
            if (reponseCat != null)
            {
                _restaurantDBContext.Categories.Remove(reponseCat);
                await _restaurantDBContext.SaveChangesAsync();
                TempData["Success"] = "Category Deleted Successfully.";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
