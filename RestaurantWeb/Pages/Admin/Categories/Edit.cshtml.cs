using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWeb.Data;
using RestaurantWeb.Models;

namespace RestaurantWeb.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty] public Category category { get; set; }

        private readonly RestaurantDBContext _restaurantDBContext;
        public EditModel(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext;
        }
        public void OnGet(int id)
        {
            category = _restaurantDBContext.Categories.Single(c=>c.Id==id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("match", "The DisplayOrder cannot match the key name.");
            }
            if (ModelState.IsValid)
            {
                _restaurantDBContext.Categories.Update(category);
                await _restaurantDBContext.SaveChangesAsync();
                TempData["Success"] = "Edit Successful";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
