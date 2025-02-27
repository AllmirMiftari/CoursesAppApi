using Microsoft.EntityFrameworkCore;
using OnlineCoursesApi.Data;
using OnlineCoursesApi.Interfaces;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.Include(c => c.Courses).ToListAsync();
        }
    }
}