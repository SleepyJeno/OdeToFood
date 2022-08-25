using Microsoft.AspNetCore.Mvc;
using OdeToFood.data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestauarantData restaurantData;

        public RestaurantCountViewComponent(IRestauarantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
    
}
