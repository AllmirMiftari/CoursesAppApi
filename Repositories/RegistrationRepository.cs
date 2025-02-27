using Microsoft.EntityFrameworkCore;
using OnlineCoursesApi.Data;
using OnlineCoursesApi.Interfaces;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {

         private readonly ApplicationDbContext _context;
        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Registration> CreateRegistration(Registration registration)
        {

            await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync();
            return registration;

        }

        public async Task<Registration> DeleteRegistration(User user, int courseid)
        {
            var registrationModel = await _context.Registrations.FirstOrDefaultAsync(x => x.UserId == user.Id && x.Course.CourseId == courseid);

            if(registrationModel == null){
                return null;
            }

            _context.Registrations.Remove(registrationModel);
            await _context.SaveChangesAsync();
            return registrationModel;
        }

        public async Task<List<Course>> GetUserRegistration(User appUser)
        {
            return await _context.Registrations.Where(u => u.UserId == appUser.Id)
            .Select(course => new Course{
                CourseId = course.CourseId,
                Title = course.Course.Title,
                Duration = course.Course.Duration,
                Description = course.Course.Description,
                Images = course.Course.Images,
                Instructor = course.Course.Instructor,
                CourseInfo = course.Course.CourseInfo,
                Rating = course.Course.Rating,
            }).ToListAsync();
        }

    }
}