using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDetail
    {
        [Key]
        public int id { get; set; }
        public int orderId { get; set; }
        public int carId { get; set; }
        public string desc { get; set; }
        public virtual Car car { get; set; }
        public virtual Order order { get; set; }
    }
}
