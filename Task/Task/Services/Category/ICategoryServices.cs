using Task.Models;

namespace Task.Services.Category
{
    public interface ICategoryServices
    {
        public IEnumerable<CategoryViewModel> GetAllCategories();
    }
}
