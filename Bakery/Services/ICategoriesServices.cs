using Entities;

namespace Services
{
    public interface ICategoriesServices
    {
        Task<List<Catgory>> getCategories();
    }
}