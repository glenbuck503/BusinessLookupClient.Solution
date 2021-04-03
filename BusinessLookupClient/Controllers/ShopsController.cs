using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLookupClient.Models;

namespace BusinessLookupClient.Controllers
{
  public class ShopsController : Controller
  {
    public IActionResult Index()
    {
      var allShops = Shop.GetShops();
      return View(allShops);
    }

    [HttpPost]
    public IActionResult Index(Shop shop)
    {
      Shop.Post(shop);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var shop = Shop.GetDetails(id);
      return View(shop);
    }

    public IActionResult Edit(int id)
    {
      var shop = Shop.GetDetails(id);
      return View(shop);
    }

    [HttpPost]
    public IActionResult Details(int id, Shop shop)
    {
      shop.ShopId = id;
      Shop.Put(shop);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Shop.Delete(id);
      return RedirectToAction("Index");
    }
  }
}