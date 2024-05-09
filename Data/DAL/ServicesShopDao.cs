using HWASP.Data.Context;
using HWASP.Data.Entities;

namespace HWASP.Data.DAL
{
    public class ServicesShopDao(DataContext context, Object dbLocker)
    {
        private readonly DataContext _context=context;
        private readonly object _dbLocker = dbLocker;
        public List<Category> GetCategories()
        {
            List<Category> categories;
            lock (_dbLocker)
            {
                categories = _context.Categories.Where(c=>c.IsActive).ToList();
            }
            return categories;
        }

        public void AddCategory(String name, String slug, String description, String imageUrl) {
            AddCategory(new()
            {
                Name = name,
                Slug = slug,
                Description = description,
                ImageUrl = imageUrl,
                IsActive = true,
                Id = Guid.NewGuid(),
            });
        }
        public void AddCategory(Category category)
        {
            lock(_dbLocker)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }
    }
}
