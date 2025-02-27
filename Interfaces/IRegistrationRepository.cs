using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<List<Course>> GetUserRegistration(User appUser);

        Task<Registration> CreateRegistration(Registration registration);

        Task<Registration> DeleteRegistration(User user, int courseid);
    }
}