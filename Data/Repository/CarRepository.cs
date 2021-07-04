using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDBContent db;

        public CarRepository(AppDBContent db)
        {
            this.db = db;
        }

        public void DeleteCar(int carId)
        {
            db.Cars.Remove(db.Cars.Single(c => c.IdCar == carId));
        }

        public IEnumerable<Car> GetAllCars()
        {
            //Тут пролапс в виде Include это типа под запрос на Join для получение еще данных о таблице Category
            return db.Cars.Include(c => c.Category).Select(c => c);
        }

        public Car GetCar(int carId)
        {
            return db.Cars.Single(c => c.IdCar == carId);
        }

        public void InsertCar(Car newCar)
        {
            db.Cars.Add(newCar);
        }
    }
}
