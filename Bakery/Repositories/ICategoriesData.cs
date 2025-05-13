using Entities;

namespace Repositories
{
    public interface ICategoriesData
    {
        Task<List<Category>> getCategory();
    }
}