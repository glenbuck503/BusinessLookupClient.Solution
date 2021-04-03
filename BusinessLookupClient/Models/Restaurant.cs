using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLookupClient.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }

    public string Name { get; set; }

    public string Food { get; set; }

    public string Number { get; set; }

    public static List<Restaurant> GetRestaurants()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Restaurant> shopList = JsonConvert.DeserializeObject<List<Restaurant>>(jsonResponse.ToString());

      return shopList;
    }

    public static Restaurant GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Restaurant shop = JsonConvert.DeserializeObject<Restaurant>(jsonResponse.ToString());

      return shop;
    }

    public static void Post(Restaurant shop)
    {
      string jsonRestaurant = JsonConvert.SerializeObject(shop);
      var apiCallTask = ApiHelper.Post(jsonRestaurant);
    }

    public static void Put(Restaurant shop)
    {
      string jsonRestaurant = JsonConvert.SerializeObject(shop);
      var apiCallTask = ApiHelper.Put(shop.RestaurantId, jsonRestaurant);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}