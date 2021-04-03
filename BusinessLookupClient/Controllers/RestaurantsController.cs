using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLookupClient.Models;

namespace BusinessLookupClient.Controllers
{
  public class RestaurantsController : Controller
  {
    public IActionResult Index()
    {
      var allRestaurants = Restaurant.GetRestaurants();
      return View(allRestaurants);
    }

    [HttpPost]
    public IActionResult Index(Restaurant shop)
    {
      Restaurant.Post(shop);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var shop = Restaurant.GetDetails(id);
      return View(shop);
    }

    public IActionResult Edit(int id)
    {
      var shop = Restaurant.GetDetails(id);
      return View(shop);
    }

    [HttpPost]
    public IActionResult Details(int id, Restaurant shop)
    {
      shop.RestaurantId = id;
      Restaurant.Put(shop);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Restaurant.Delete(id);
      return RedirectToAction("Index");
    }
  }
}