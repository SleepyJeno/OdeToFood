using OdeToFood.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.data
{
    public interface IRestauarantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant); //takes restaurant and returns updated one
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int ID);
        int GetCountOfRestaurants();
        int Commit();
    }
}
