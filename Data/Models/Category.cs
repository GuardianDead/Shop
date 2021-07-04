using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Desc { get; set; }

        public Category()
        {

        }
        public Category(int id, string desc)
        {
            Id = id;
            Desc = desc;
        }
    }
}
