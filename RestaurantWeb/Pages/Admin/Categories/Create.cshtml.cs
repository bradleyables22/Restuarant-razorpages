using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWeb.Data;
using RestaurantWeb.Models;
using RestaurantWeb.Repository.IRepository;

namespace RestaurantWeb.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        
        private readonly ICategoryRepository _catRep;
        [BindProperty] public Category category { get; set; }

        public CreateModel(ICategoryRepository catRep) => _catRep = catRep;

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
