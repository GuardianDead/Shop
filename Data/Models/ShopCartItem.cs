using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        [Key]
        [Required]
        public int ItemId { get; set; }
        //Предмет который может быть в корзине
        public Car Car { get; set; }
        //Id как бы корзины
        public string ShopCartId { get; set; }
    }
}
