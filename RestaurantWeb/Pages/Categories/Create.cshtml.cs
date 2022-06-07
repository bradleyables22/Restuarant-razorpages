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
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("match", "The DisplayOrder cannot match the key name.");
            }
            if (ModelState.IsValid)
            {
                await _restaurantDBContext.Categories.AddAsync(category);
                await _restaurantDBContext.SaveChangesAsync();
                TempData["Success"] = "Category create successfully!";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
