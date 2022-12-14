using OdeToFood.core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.data
{
    public class InMemoryRestaurantData : IRestauarantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData() {
            restaurants = new List<Restaurant>()
            { 
            new Restaurant { ID = 1, Name = "Icco Pizza", Location = "London", Cuisine = CuisineType.Italian },
            new Restaurant { ID = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian},
            new Restaurant { ID = 3, Name = "Coppa Club", Location = "London", Cuisine = CuisineType.British}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.ID == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.ID = restaurants.Max(r => r.ID) + 1;
            return newRestaurant;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.ID == updatedRestaurant.ID);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Delete(int ID)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.ID == ID);
            if (restaurant != null){
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
