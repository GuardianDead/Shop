using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContent db;

        public CategoryRepository(AppDBContent db)
        {
            this.db = db;
        }

        public void DeleteCategory(int categoryId)
        {
            db.Categories.Remove(db.Categories.Single(c => c.Id == categoryId));
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.Select(c => c);
        }

        public Category GetCategory(int categoryId)
        {
            return db.Categories.Single(c => c.Id == categoryId);
        }

        public void InsertCategory(Category newCategory)
        {
            db.Categories.Add(newCategory);
        }
    }
}
