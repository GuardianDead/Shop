using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICarRepository carRepository;
        private readonly ShopCart shopCart;

        public ShopCartController(ICarRepository carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository;
            this.shopCart = shopCart;
        }

        //Создаем страничку под названием Index по пути ShopCart/Index
        public ViewResult Index()
        {
            //Получаем предметы которые хранятся в корзине пользователя в его текущей сессии и закидываем их в общий объект 'Корзина'
            shopCart.ListShopsItems= shopCart.GetShopItems();

            ShopCartViewModel obj = new ShopCartViewModel();

            obj.ShopCart = shopCart;

            return View(obj);
        }

        //Переадрисовка на другую страницу
        public RedirectToActionResult AddToCart(int itemId)
        {
            //Выборка именного того товара id которого существует вообще в нашем магазине
            var item = carRepository.GetAllCars().FirstOrDefault(i => i.IdCar==itemId);

            //Чекаем вообще нашли мы предмет и закидываем его корзину пользователя
            if (item != null)
            {
                shopCart.AddToCart(item);
            }

            //На какую страничку переходим после всего этого дерьме выше
            return RedirectToAction("Index");
        }
    }
}
