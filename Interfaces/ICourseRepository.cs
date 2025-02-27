using OnlineCoursesApi.Helpers;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesAsync(); 

        Task<List<Course>> GetCoursesByCategoryAsync(string name);

        Task<List<Course>> GetFilteredCoursesAsync(QueryObject query);

        Task<Course> GetCourseByIdAsync(int courseId);
    }
}