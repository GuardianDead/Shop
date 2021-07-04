using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Mock
{
    public class MockCategoryRepository : ICategoryRepository
    {
        List<Category> categories = new List<Category>()
        {
            new Category(1,"Электронные машинки"),
            new Category(2,"Дизельные машинки")
        };

        public void DeleteCategory(int categoryId)
        {
            categories.Remove(GetCategory(categoryId)); 
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategory(int categoryId)
        {
            return categories.Single(c => c.Id==categoryId);
        }

        public void InsertCategory(Category newCategory)
        {
            categories.Add(newCategory);
        }
    }
}
