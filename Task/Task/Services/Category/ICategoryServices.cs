using Task.Models;

namespace Task.Services
{
    public interface ICategoryServices
    {
        public IEnumerable<CategoryViewModel> GetAllCategories();
    }
}
