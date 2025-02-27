using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}