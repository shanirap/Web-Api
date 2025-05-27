using DTOs;
using Entities;

namespace Services
{
    public interface ICategoriesServices
    {
        Task<List<CategoryDto>> getCategories();
    }
}