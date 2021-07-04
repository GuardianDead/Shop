using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using Shop.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class InitialDbObjects
    {
        static public void InitialDB(AppDBContent db)
        {

            if (!db.Categories.Any() && !db.Categories.Any())
            {
                List<Category> categories = new List<Category>()
                {
                    new Category()
                    {
                        Desc="Электронная машинка"
                    },
                    new Category()
                    {
                        Desc="Дизельная машинка"
                    }
                };
                List<Car> cars = new List<Car>()
                {
                    new Car()
                    {
                        DescCar="Тесла",
                        Category=categories[0]
                    },
                    new Car()
                    {
                        DescCar="BWM",
                        Category=categories[1]
                    },
                    new Car()
                    {
                        DescCar="GreenPeace",
                        Category=categories[0]
                    },
                    new Car()
                    {
                        DescCar="Toyta",
                        Category=categories[1]
                    }
                };

                db.Cars.AddRange(cars);
                db.Categories.AddRange(categories);
            }

            //Вот этот асинковйы парень может тебе пояснить за твою маму, держи его на цепи
            db.SaveChanges();
        }
    }
}
