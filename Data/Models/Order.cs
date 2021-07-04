using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(10)]
        [Required( ErrorMessage = "Имя содержит свыше 10 символов")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(20)]
        [Required(ErrorMessage = "Фимилия содержит свыше 20 символов")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(40)]
        [Required(ErrorMessage = "Адрес содержит свыше 40 символов")]
        public string adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Номер телефона содержит свыше 15 символов")]
        public string phone { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Имя содержит свыше 30 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime  { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
