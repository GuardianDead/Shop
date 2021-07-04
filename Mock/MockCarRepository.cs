using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Mock
{
    public class MockCarRepository : ICarRepository
    {
        List<Car> cars = new List<Car>();

        MockCategoryRepository mockCategoryRepository = new MockCategoryRepository();

        public MockCarRepository()
        {
            cars.Add(new Car(1,"Тесла",mockCategoryRepository.GetCategory(1)));
            cars.Add(new Car(2, "BMW", mockCategoryRepository.GetCategory(2)));
            cars.Add(new Car(3, "AUDI", mockCategoryRepository.GetCategory(2)));
            cars.Add(new Car(4, "GreenPeace", mockCategoryRepository.GetCategory(1)));
            cars.Add(new Car(5, "Жигуль", mockCategoryRepository.GetCategory(2)));
        }

        public void DeleteCar(int carId)
        {
            cars.Remove(GetCar(carId));
        }

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public Car GetCar(int carId)
        {
            return cars.Single(c => c.IdCar == carId);
        }

        public void InsertCar(Car newCar)
        {
            cars.Add(newCar);
        }
    }
}
