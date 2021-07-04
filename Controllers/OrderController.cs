using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders orders;
        private readonly ShopCart shopCart;
        public OrderController(IOrders orders, ShopCart shopCart)
        {
            this.orders = orders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        //Каким методом (Post) мы принимаем от HTML странички значения
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopsItems = shopCart.GetShopItems();

            if(shopCart.ListShopsItems.Count == 0)
            {
                ModelState.AddModelError("","Корзина пуста");
                return RedirectToAction("Error");
            }

            if (ModelState.IsValid)
            {
                orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View();
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.Error = "Корзина пуста";
            return View();
        }
    }
}
