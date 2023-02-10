using DB;
using Task.Models;

namespace Task.Services
{
    public class CategryServices : ICategoryServices
    {
        private readonly Context Db;
        public CategryServices(Context _db)
        {
            Db = _db;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var CategoryList= Db.category.Select(c=> new CategoryViewModel
            {
                Id= c.Id,
                Name = c.Name,
            });
            return CategoryList;
            
        }
    }
}
