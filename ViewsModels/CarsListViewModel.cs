using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewsModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Category> CurrentCategory { get; set; }
    }
}
