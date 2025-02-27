using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}