using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository carRepository;
        public HomeController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public ViewResult Index()
        {
            HomeIndexViewModel obj = new HomeIndexViewModel();
            obj.Cars = carRepository.GetAllCars().Where(c => c.Category.Desc == "Электронная машинка");

            return View(obj);
        }
    }
}
