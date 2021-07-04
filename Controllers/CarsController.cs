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
    public class CarsController : Controller 
    {
        private readonly ICarRepository carRepository;
        private readonly ICategoryRepository categoryRepository;

        public CarsController(ICarRepository carRepository, ICategoryRepository categoryRepository)
        {
            this.carRepository = carRepository;
            this.categoryRepository = categoryRepository;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category?}/{id?}")]
        public ViewResult List(string category)
        {
            CarsListViewModel obj = new CarsListViewModel();

            if (string.IsNullOrEmpty(category))
            {
                obj.Cars = carRepository.GetAllCars().OrderBy(c => c.IdCar);
            }
            else
            {
                if (string.Equals("Electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    obj.Cars = carRepository.GetAllCars().Where(c => c.Category.Desc=="Электронная машинка");
                } else if (string.Equals("Fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    obj.Cars = carRepository.GetAllCars().Where(c => c.Category.Desc == "Дизельная машинка");
                }
            }

            return View(obj);
        }
    }
}
