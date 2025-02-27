using Microsoft.EntityFrameworkCore;
using OnlineCoursesApi.Data;
using OnlineCoursesApi.Helpers;
using OnlineCoursesApi.Interfaces;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {

        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(c=>c.CourseId == courseId);
        }

        public async Task<List<Course>> GetCoursesByCategoryAsync(string name)
        {
            return await _context.Courses.Where(c => c.Category.Name == name).ToListAsync();
        }

        public async Task<List<Course>> GetFilteredCoursesAsync(QueryObject query)
        {
            var filteredCourses = _context.Courses.AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.searchTitle)){
                filteredCourses = filteredCourses.Where(c => EF.Functions.Like(c.Title.ToLower(), $"%{query.searchTitle.ToLower()}%"));
            }

            return await filteredCourses.ToListAsync();
        }
    }
}