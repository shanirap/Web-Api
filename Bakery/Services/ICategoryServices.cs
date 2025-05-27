using DTOs;
using Entities;

namespace Services
{
    public interface ICategoryServices
    {
        Task<List<CategoryDTO>> getCategory();
    }
}