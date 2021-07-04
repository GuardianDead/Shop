using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCar(int carId);
        void InsertCar(Car newCar);
        void DeleteCar(int carId);
    }
}
