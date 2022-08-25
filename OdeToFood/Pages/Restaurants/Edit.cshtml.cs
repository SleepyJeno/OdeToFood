using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.core;
using OdeToFood.data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestauarantData restauarantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        
        public EditModel(IRestauarantData restauarantData,
                         IHtmlHelper htmlHelper)
        {
            this.restauarantData = restauarantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue) {
                Restaurant = restauarantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            // check if new or existing restaurant
            if (Restaurant.ID > 0)
            {
                restauarantData.Update(Restaurant);
                // inbuilt data structure for passing temporary messages between pages. stateless
                TempData["Message"] = "Restaurant updated!";
            }
            else
            {
                restauarantData.Add(Restaurant);
                // inbuilt data structure for passing temporary messages between pages. stateless
                TempData["Message"] = "Restaurant created!";
            }
            restauarantData.Commit();
            // redirect to the detail page for the same resto by ID
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.ID });

            
        }
    }
}
