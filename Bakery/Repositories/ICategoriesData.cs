using Entities;

namespace Repositories
{
    public interface ICategoriesData
    {
        Task<List<Catgory>> getCatgories();
    }
}