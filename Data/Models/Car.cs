using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Car
    {
        [Key]
        [Required]
        public int IdCar { get; set; }
        public string DescCar { get; set; }
        public virtual Category Category { get; set; }
        public Car()
        {

        }
        public Car(int idCar, string descCar, Category category)
        {
            IdCar = idCar;
            DescCar = descCar;
            Category = category;
        }
    }
}
